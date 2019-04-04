$(document).ready(function () {

    alert("Entre");
    searchEmployees();


    $("#btnSearch").click(function () {

        var Id = $("#txtIdEmployee").val();
        $("#tblClientes tr").detach();
       SearchById(Id);
    });

});

function SearchById(Id) {

    $.ajax({
        url: '/Employee/SearchEmployees/?Id=' + Id,
        type: 'POST',
        datatype: 'JSON',
        data: Id,
        success: function (respuesta) {


            var tablaBody = "";            

            $.each(respuesta, function (indice, item) {

                tablaBody += "<tr>";
                tablaBody += "<td>" + item.Id + "</td>";
                tablaBody += "<td> " + item.Name + "</td>";
                tablaBody += "<td>" + item.ContractTypeName + "</td>";
                tablaBody += "<td>" + item.RoleName + "</td>";
                tablaBody += "<td>" + item.RoleDescription + "</td>";
                tablaBody += "<td>" + item.AnnualSalary + "</td>";
                tablaBody += "</tr> ";

            });


           


            $('#tblClientes tbody').append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}

function searchEmployees() {

    $.ajax({
        url: '/Employee/SearchEmployees',
        type: 'POST',
        datatype: 'JSON',        
        data: { data: '0'},
        success: function (respuesta) {
            var tablaBody = "";

            $.each(respuesta, function (indice, item) {

                tablaBody += "<tr>";
                tablaBody += "<td>" + item.Id + "</td>"; 
                tablaBody += "<td> " + item.Name + "</td>";
                tablaBody += "<td>" + item.ContractTypeName + "</td>";
                tablaBody += "<td>" + item.RoleName + "</td>";
                tablaBody += "<td>" + item.RoleDescription + "</td>";
                tablaBody += "<td>" + item.AnnualSalary + "</td>";
                tablaBody += "</tr> ";

            });


            $('#tblClientes tbody').append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}