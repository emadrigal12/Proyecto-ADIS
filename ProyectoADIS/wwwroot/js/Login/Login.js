function iniciarSesion() {
    let usuario = $("#txtUsuario").val()
    let contraseña = $("#txtContrasena").val();
    // Validar campos vacíos
    if (usuario === '' || contraseña === '') {
        document.getElementById("mensajeError").innerHTML = "Por favor, complete todos los campos.";
        return;
    }
    if (contraseña !== "Ulacit2024#") {
        return document.getElementById("mensajeError").innerHTML = "Usuario y contraseña inválidos, reintente nuevamente.";
    }
    // Validar de correo institucional
    if (!usuario.endsWith("@ulacit.ed.cr")) {
        document.getElementById("mensajeError").innerHTML = "El correo institucional debe pertenecer al dominio '@ulacit.ed.cr'.";
        return;
    }

    // Validar contraseña
    let regexContrasena = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,15}$/;
    if (!regexContrasena.test(contraseña)) {
        document.getElementById("mensajeError").innerHTML = "Contraseña: 8-15 caracteres, 1 mayúscula, 1 minúscula, 1 carácter especial, 1 número.";
        return;
    }
    checkPrimerLogin();
} 


function checkPrimerLogin() {
    let primerLogin = true
    if (primerLogin) {
        $('#actualizarContra').modal('show')
    } 

    return primerLogin
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
