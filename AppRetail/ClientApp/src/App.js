import 'bootstrap/dist/css/bootstrap.min.css';
import { useState, useEffect } from 'react'
import { Table } from './components/Table'
import { Form } from './components/Form'
import { InputForm } from './components/InputForm'

const App = () => {
    const [clientes, setClientes] = useState([])
    const [editarCliente, setEditarCliente] = useState(false);
    const [obtenerDni, setObtenerDni] = useState(0)

    const consumirAPI = async () => {
        const respuesta = await fetch("api/cliente/ObtenerCliente")
        const data = await respuesta.json();
        console.log(data)
        setClientes(data);
    }

    function handleSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target)
        const cliente = {
            dni: form.get('dni'),
            nombre: form.get('nombre'),
            direccion: form.get('direccion'),
            correoElectronico: form.get('correoElectronico'),
            numeroTelefono: form.get('numeroTelefono')
        }

        fetch('api/cliente/AgregarCliente', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(cliente)
        })
            .then(response => {
                if (response.ok) {
                    console.log('Cliente agregado!');
                    consumirAPI()

                } else {
                    console.error('Hubo un problema al agregar el cliente.');
                }
            });
    }

    function handleSubmitPut(event) {
        event.preventDefault();
        const form = new FormData(event.target)
        const cliente = {
            nombre: form.get('nombre'),
            direccion: form.get('direccion'),
            correoElectronico: form.get('correoElectronico'),
            numeroTelefono: form.get('numeroTelefono')
        }

        fetch(`api/cliente/ActualizarCliente?dni=${obtenerDni}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(cliente)
        })
            .then(response => {
                if (response.ok) {
                    console.log('Cliente actualizado!');
                    consumirAPI()
                    setEditarCliente(!editarCliente)
                } else {
                    console.error('Hubo un problema al agregar el cliente.');
                }
            });
    }

    function handleClick(dni) {
        setObtenerDni(dni)
        setEditarCliente(!editarCliente)
    }

    useEffect(() => {
        consumirAPI();
    }, [])

    return (
        <>
           
            <Table clientes={clientes} handleClick={handleClick} />
            {!editarCliente && <h1>Agregar Cliente</h1>}
            {editarCliente && <h1>Editar Cliente</h1>}
            <Form handleSubmit={editarCliente ? handleSubmitPut : handleSubmit}>
                {!editarCliente && <InputForm type="number" name="dni"/>}
              
                <InputForm type="text" name="nombre" />
                <InputForm type="text" name="direccion" />
                <InputForm type="email" name="correoElectronico" />
                <InputForm type="number" name="numeroTelefono" />
            </Form>
        </>
        )
}
export {App}