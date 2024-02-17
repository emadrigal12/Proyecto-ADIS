function iniciarSesion() {
    console.log("Entro")
    var usuario = document.getElementById("txtUsuario").value;
    var contraseña = document.getElementById("txtContrasena").value;
    // Validar campos vacíos
    if (usuario === '' || contraseña === '') {
        document.getElementById("mensajeError").innerHTML = "Por favor, complete todos los campos.";
        return;
    }
    // Validar de correo institucional
    if (!usuario.endsWith("@ulacit.ed.cr")) {
        document.getElementById("mensajeError").innerHTML = "El correo institucional debe pertenecer al dominio '@ulacit.ed.cr'.";
        return;
    }

    // Validar contraseña
    var regexContrasena = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,15}$/;
    if (!regexContrasena.test(contraseña)) {
        document.getElementById("mensajeError").innerHTML = "Contraseña: 8-15 caracteres, 1 mayúscula, 1 minúscula, 1 carácter especial, 1 número.";
        return;
    }
    alert("¡Bienvenido a la plataforma!");
} 

