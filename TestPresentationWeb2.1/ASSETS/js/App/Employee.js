$(document).ready(function () {

    alert("Entre");
    searchEmployees();

});


function searchEmployees() {

    $.ajax({
        url: '/Employee/SearchEmployees',
        type: 'POST',
        datatype: 'JSON',        
        data: { data:'1' },
        success: function (respuesta) {
            var tableBody = "";

            $.each(respuesta, function (indice, item) {

                tablaBody += "<tr>";
                tablaBody += "<td>" + item.Id + "</td>"; 
                tablaBody += "<td> " + item.Nombres + "</td>";
                tablaBody += "<td>" + item.Apellidos + "</td>";
                tablaBody += "<td>" + item.NombreTipoDocumento + "</td>";
                tablaBody += "<td>" + item.Identificacion + "</td>";
                tablaBody += "</tr> ";

            });


            $('#tblClientes tbody').append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}