var url = 'https://localhost:44331/GetObras'

function listObras() {
    fetch(url)
        .then(response => response.json())
        .then(data =>  {
            console.log(data)

            const cuerpoTabla = document.querySelector('tbody')
            cuerpoTabla.innerHTML = '';

            data.forEach(obra => {
                        const fila = document.createElement('tr');
                        fila.classList.add('text-bg-dark')

                        fila.innerHTML += `<td>${obra.nombre}</td>`
                        fila.innerHTML += `<td>${obra.datosVarios}</td>`
                        fila.innerHTML += `<td>${obra.tipoObra}</td>`
                        fila.innerHTML += `<td>${obra.cantAlb}</td>`

                        const accionesTd = document.createElement('td');
                        if(obra.tipoObra == 'Edificio') {
                            const button = document.createElement('button');
                            button.textContent = 'Asignar albañil';
                            button.classList.add('btn', 'btn-primary');
                            button.onclick = () => {
                                window.location.href = `http://127.0.0.1:5500/html/Pag2.html?id=${obra.id}`
                            };
                            accionesTd.appendChild(button);
                        }

                        fila.appendChild(accionesTd);
                        cuerpoTabla.appendChild(fila);
                });
            })
            .catch(err => {
                console.error("Error al cargar los datos: ", err);
                alert("Algo salió mal... " + err);
            })
}