document.addEventListener("DOMContentLoaded",  function () {

    const form = document.getElementById('albanilForm');

    form.addEventListener('submit', async function(event) {

        event.preventDefault();

        const nombre = document.getElementById("nombre").value;
        const apellido = document.getElementById("apellido").value;
        const dni = document.getElementById("dni").value;
        const telefono = document.getElementById("telefono").value;
        const calle = document.getElementById("calle").value;
        const numero = document.getElementById("numero").value;
        const codPost = document.getElementById("codPost").value;
        const fechaAlta = document.getElementById("fechaAlta").value;
        const activo = document.getElementById("activo").checked;

        const albanil = {
            nombre: nombre,
            apellido: apellido,
            dni: dni,
            telefono: telefono,
            calle: calle,
            numero: numero,
            codPost: codPost,
            fechaAlta: fechaAlta,
            activo: activo
        }

        if(!nombre || !apellido || !dni || !fechaAlta) {
            alert("Complete los campos obligatorios")
        }

        const response = await fetch('https://localhost:44331/PostAlbanil', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify(albanil)
        })
        
        const responseData = await response.json();

        if(!responseData.success) {
            alert(responseData.message)
            return;
        }

        alert(responseData.message)
        form.reset();
    })
})