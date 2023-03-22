import 'bootstrap/dist/css/bootstrap.min.css';

const Table = ({ clientes, handleClick }) => {
    return (
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Dni#</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Direccion</th>
                    <th scope="col">Correo</th>
                    <th scope="col">Telefono</th>
                </tr>
            </thead>
            <tbody>
                {clientes.map(c => {
                    return (
                        <tr key={c.dni}>
                            <th scope="row">{c.dni}</th>
                            <td>{c.nombre}</td>
                            <td>{c.direccion}</td>
                            <td>{c.correoElectronico}</td>
                            <td>{c.numeroTelefono}</td>
                            <td onClick={() => handleClick(c.dni) }>Editar</td>
                        </tr>
                    )
                })}


            </tbody>
        </table>
        )
}

export {Table }