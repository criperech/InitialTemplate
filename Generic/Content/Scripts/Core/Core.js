(function ($) {
    $.CoreJs = function (options) {
        //Contexto
        var $coreJs = this;

        let Test = function () {
            alert("CoreJs Works!");
        }

        //Fución encargada de ejecutar peticiones Ajax
        let HttpClient = function (controller, action, data, callBackSuccess, callBackError) {

            var settings = {
                type: 'POST',
                // [Ruta absoluta Admin ] / [controler] / [action]
                url: $url + '/' + controller + '/' + action,
                data: data,
                success: function (response) {
                    callBackSuccess(response);
                },
                error: function (xhr, status, error) {
                    console.log("Core HTTP ERROR", xhr);
                    callBackError(error);
                }
            };
            $.ajax(settings);

        }


        //Retornamos las funciones
        return {
            Test: Test,
            HttpClient: HttpClient
        }
    }
})(jQuery);