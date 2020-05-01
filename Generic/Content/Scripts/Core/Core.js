(function ($) {
    $.CoreJs = function (options) {
        //Contexto
        var $coreJs = this;

        let Test = function () {
            alert("CoreJs Works!");
        }



        //Retornamos las funciones
        return {
            Test: Test
        }
    }
})(jQuery);