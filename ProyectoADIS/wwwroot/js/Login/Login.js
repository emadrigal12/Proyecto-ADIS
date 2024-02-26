function validacionesLogin() {
    let usuario = $("#txtUsuario").val()
    let contraseña = $("#txtContrasena").val();
    // Validar campos vacíos
    if (usuario === '' || contraseña === '') {
        document.getElementById("mensajeError").innerHTML = "Por favor, complete todos los campos.";
        return false;
    }
    if (contraseña !== "Ulacit2024#") {
        document.getElementById("mensajeError").innerHTML = "Usuario y contraseña inválidos, reintente nuevamente.";
        return false
    }
    // Validar de correo institucional
    if (!usuario.endsWith("@ulacit.ed.cr")) {
        document.getElementById("mensajeError").innerHTML = "El correo institucional debe pertenecer al dominio '@ulacit.ed.cr'.";
        return false;
    }

    // Validar contraseña
    let regexContrasena = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,15}$/;
    if (!regexContrasena.test(contraseña)) {
        document.getElementById("mensajeError").innerHTML = "Contraseña: 8-15 caracteres, 1 mayúscula, 1 minúscula, 1 carácter especial, 1 número.";
        return false;
    }
    return checkPrimerLogin();
} 


function validarContrasena(contrasena) {
    let regexContrasena = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,15}$/;
    return regexContrasena.test(contrasena)
}

function ActualizarContrasena() {
    let usuario = $("#txtUsuario").val()
    let contraActual = $('#contraActual').val()
    let contraNueva = $('#contraNueva').val()
    let confirmarContra = $('#confirmarContra').val()
    if (contraActual == '' || contraNueva == '' || confirmarContra == '') {
        return document.getElementById("mensajeErrorContra").innerHTML = "Por favor, complete todos los campos.";
    }
    if (contraActual !== "Ulacit2024#") {
        return document.getElementById("mensajeErrorContra").innerHTML = "Contraseña actual incorrecta.";
    }
    if (!validarContrasena(contraNueva)) {
        return document.getElementById("mensajeErrorContra").innerHTML = "Contraseña nueva debe tener: 8-15 caracteres, 1 mayúscula, 1 minúscula, 1 carácter especial, 1 número.";
    }
    if (contraNueva !== confirmarContra) {
        return document.getElementById("mensajeErrorContra").innerHTML = "No coincide la contraseña nueva con la confirmada.";
    }
    document.getElementById("mensajeErrorContra").innerHTML = "";


    const dataUpdatePassword = {
        Usuario: usuario,
        newPassword: contraNueva,
        actualPassword: contraActual,
        Password: contraNueva
    };
        

    const response = fetch(`${LOGIN_URL}/UpdatePassword`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dataUpdatePassword)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Usuario y contraseña inválidos, reintente nuevamente.');
        }
        return response.json();
    })
    .then(data => {
        console.log(data)
        switch (data.code) {
            case 1:
                toastr.success('Contraseña cambiada exitosamente.');
                setTimeout(() => {
                    console.log("Se debe actualizar")
                    $('#actualizarContra').modal('hide');
                    window.location.href = "/Login/Index";
                }, 2000);
                break;
            case 2:
                $('#mensajeErrorContra').text(data.message);
                break;
            default:
                throw new Error('Error desconocido.');
        }
    })
    .catch(error => {
        $('#mensajeErrorContra').text(error.message);
    });

    
}

function iniciarSesion() {
    let usuario = $("#txtUsuario").val();
    let contrasena = $("#txtContrasena").val();

    var data = {
        Usuario: usuario,
        Password: contrasena
    };

    fetch(`${LOGIN_URL}/IniciarSesion`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Usuario y contraseña inválidos, reintente nuevamente.');
            }
            return response.json();
        })
        .then(data => {
            console.log(data.message)

            switch (data.code) {
                case 1:
                    window.location.href = "/Home/Index";
                    break;
                case 2:
                    $('#actualizarContra').modal('show');
                    break;
                case 3:
                    $('#mensajeError').text(data.message);
                    break;
                default:
                    throw new Error('Error desconocido.');
            }
        })
        .catch(error => {
            $('#mensajeError').text(error.message);
        });
}




