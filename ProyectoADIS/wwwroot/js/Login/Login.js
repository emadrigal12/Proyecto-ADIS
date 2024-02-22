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
    toastr.success('Contraseña cambiada exitosamente.');

    setTimeout(() => {
        window.location.reload;
    }, 2000);
}

function iniciarSesion() {
    if (validacionesLogin()) {
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
                    throw new Error('Invalid username or password');
                }
                window.location.href = "/Home/Index";
            })
            .catch(error => {
                $('#mensajeError').text(error.message);
            });
    }
}


async function checkPrimerLogin() {
    try {
        const response = await fetch($`/${LOGIN_URL}/CheckPrimerLogin`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error('Error al verificar el primer inicio de sesión');
        }

        const data = await response.json();
        const primerLogin = data.primerLogin;

        if (primerLogin) {
            $('#actualizarContra').modal('show');
        }

        return primerLogin;
    } catch (error) {
        console.error('Ocurrió un error:', error);
        return false;
    }
}