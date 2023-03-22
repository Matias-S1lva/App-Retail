const InputForm = ({ type, name }) => {
    return (
        <div className="form-floating">
            <input type={type} className="form-control" name={name} placeholder={ name} />
            <label for={"floating" + name}>{ name}</label>
        </div>
        )
}

export { InputForm }