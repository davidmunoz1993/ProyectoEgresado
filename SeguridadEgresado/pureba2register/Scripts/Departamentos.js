$(document).ready(function () {
        $("#DepartamentoID").change(function () {
            $("#MunicipioID").empty();
            $.ajax({
                type: 'POST',
                url: '/InformacionPersonals/GetCities',
                dataType: 'json',
                data: { departmentId: $("#DepartamentoID").val() },
                success: function (Cities) {
                    $.each(Cities, function (i, cuidad) {
                        $("#MunicipioID").append('<option value="'
                            + cuidad.MunicipioID + '">'
                            + cuidad.NombreMunicipio + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Error al retornar las ciudades.' + JSON.stringify(ex));
                }
            });
            return false;
        })
    });