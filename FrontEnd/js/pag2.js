$(document).ready(function () {

    const params = new URLSearchParams(window.location.search);
    const obraId = params.get('id');

    if(obraId) {
        $('#obra-id').text(`Obra ID: ${obraId}`);
    
        $.get(`https://localhost:44331/GetAlbaniles/${obraId}`, function (albaniles) {
            const select = $('#albanilSelect');
            select.empty();

            console.log(Array.from(albaniles).length)

            if(albaniles && Array.from(albaniles).length) {
                albaniles.forEach(albanil => {
                    select.append(`<option value=${albanil.id}>${albanil.nombre} ${albanil.apellido}</option>`);
                });
            } else {
                select.append(`<option disabled>No hay albañiles disponibles</option>`);
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error al cargar los albañiles: ' + textStatus);
        });

        $('#asignarBtn').click(function () {
            const albanilId = $('#albanilSelect').val();
            const tarea = $('#tareaTextArea').val();

            console.log(albanilId)

            if(albanilId && tarea) {
                

                const data = {
                    tareaARealizar: tarea,
                    fechaAlta: new Date().toISOString(),
                    albanilId: albanilId,
                    obraId: obraId
                };

                $.ajax({
                    url: 'https://localhost:44331/PostAlbanilXObra',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function() {
                        alert('Albañil asignado correctamente.');
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert('Error al asignar albañil: ' + textStatus);
                    }
                })
            } else {
                alert('Por favor, complete todos los campos.');
            }
        })
    } else {
        alert('ID de obra no proporcionado.');
    }
});