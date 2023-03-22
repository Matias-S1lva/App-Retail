import 'bootstrap/dist/css/bootstrap.min.css';

const Form = ({ children, handleSubmit }) => {

    

    return (
        <form className="container" action="api/cliente/AgregarCliente" method="post" onSubmit={handleSubmit}>
            {children }
            <div className="form-floating">
                <button type="submit" className="btn btn-primary">Submit</button>
            </div>
        </form>
    )
}
export { Form }