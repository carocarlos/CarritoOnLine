$(document).ready(function () {


    $("#botonTabla").click(function () {
        $.ajax({
            type: "POST",
            url: "Services/UsuarioService.svc/GetUsuarios",
            cache: true,
            async: false,
            data: "{}",   //'{name: "' + $("#txtName").val() + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (resultado) {
                //alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
                var items = resultado.d;
                $.each(items, function (index, item) {
                    $("#Contenido").append("<tr><td class='customerid'>" + item.vId
                        + "</td><td class='tdDatos'>" + item.vNombre + "</td>"
                        + "</td><td class='tdDatos'>" + item.vEdad + "</td></tr>");

                });
            },
            error: function (response) {
                alert("Se presentó un error");
            }
        });
    });

    $("#btnNewUser").click(function () {
        abiriModal();
    });

    function abiriModal() {
        $("#FormModal").modal("show");
    }

    $("#SaveUser").click(function () {
        var usuario = {};
        usuario.Nombres = $("#txtnombre").val();
        usuario.Apellidos = $("#txtApellido").val();  
        usuario.Correo = $("#txtmail").val();
        usuario.Activo = $("#cboActivo").val();

        $.ajax({
            type: "POST",
            url: "/Home/SaveUser",            
            data: '{ Objusuario: ' + JSON.stringify(usuario) + ' }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert(data);                              
            },
            error: function (data) {
                alert("Se presentó un error " + data);
            }
        });
    });


 
});


