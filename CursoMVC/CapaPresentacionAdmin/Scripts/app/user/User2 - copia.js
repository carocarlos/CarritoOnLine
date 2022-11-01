$(document).ready(function () {

    //Cargue de la tabla de usuarios 
    var tablaData;
    tablaData = $("#tabla").DataTable({
        responsive: true,
        ordering: false,
        "ajax": {
            url: "/Home/ListarUsuarios",
            type: "GET",
            dataType: "json"
        },
        "columns":
            [
                { "data": "Nombres" },
                { "data": "Apellidos" },
                { "data": "Correo" },
                {
                    "data": "Activo", "render": function (valor) {
                        if (valor) {
                            return '<span class="badge bg-success">Si</span>'
                        } else {
                            return '<span class="badge bg-danger">No</span>'
                        }
                    }
                },
                {
                    'defaultContent': '<button type="button" class="btn btn-primary btn-sm btn-editar"><i class="fas fa-pen"></i></button>' +
                        '<button type="button" class="btn btn-danger btn-sm ms-2"><i class="fas fa-trash"></i></button>',
                    'orderable': false,
                    'searchable': false,
                    'width': '90px'
                }
            ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json"
        }
    });

    //Cargue del Modal Nuevo usuario
    $("#btnNewUser").click(function () {
        abiriModal();                
    });

    //Boton para guardar un usuario
    $("#SaveUser").click(function () {
        var usuario = {};
        usuario.Nombres = $("#txtnombre").val();
        usuario.Apellidos = $("#txtApellido").val();
        usuario.Correo = $("#txtmail").val();    
        usuario.Activo = $("#cboActivo").val(); //Validar porque no esta Guardando bien
        

        $.ajax({
            type: "POST",
            url: "/Home/SaveUser",
            data: '{ Objusuario: ' + JSON.stringify(usuario) + ' }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Se grego el usuario de manera correcta");        
            },
            error: function (data) {
                alert("Se presentó un error ");
    
            }
        });
    });
    
    //
    $("#tabla tbody").on("click", '.btn-editar', function () {

        var vfilaSeleccionada = $(this).closest("tr"); //Se obtiene la fila seleccionada
        var data = tablaData.row(vfilaSeleccionada).data();        
        abiriModal(data);
    })




    //-------------------------------------------Funciones ---------------------------------------------//
    function abiriModal(json) {

        $("#txtId").val(0);
        $("#txtnombre").val("");
        $("#txtApellido").val("");
        $("#txtmail").val("");
        $("#cboActivo").val(1); 

        if (json != null) {
            $("#txtId").val(json.IdUsuario);
            $("#txtnombre").val(json.Nombres);
            $("#txtApellido").val(json.Apellidos);
            $("#txtmail").val(json.Correo);
            $("#cboActivo").val(json.Activo == true ? 1 : 0); 

        }
        console.log(json);
        $("#FormModal").modal("show");
    }
    
});


