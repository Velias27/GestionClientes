$(document).ready(function () {
    $('#tblClientes').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
        },
        responsive: true
    });
});

//Función para actualizar la hora cada segundo
function actualizarHora() {
    const reloj = document.getElementById("horaActual");
    const ahora = new Date();
    if (reloj) reloj.textContent = ahora.toLocaleTimeString();
}
setInterval(actualizarHora, 1000);
actualizarHora();

//Esta función abre el modal de confirmar eliminacion de Cliente
function confirmarEliminacion(idCliente) {
    document.getElementById('MainContent_hfEliminarId').value = idCliente;
    var modal = new bootstrap.Modal(document.getElementById('modalEliminar'));
    modal.show();
}