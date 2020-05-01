let DashBoard = function ($model) {

    return {

        Load: function () {
            let DashBoardApp = new Vue({
                el: "#dashboard-module",
                data: {
                    test: "Vue Works"

                },
                methods: {

                    pruebaHttp: function () {

                        $.CoreJs().HttpClient("DashBoard", "TestConectWithApi", { param1: "Andres", param2: 5, param3: false },
                            function ($response) {
                                console.log("Success AJAX", $response);
                            },
                            function ($error) {
                                console.log("ERROR AJAX : ", $error);
                            });
                    }

                },
                mounted: function () {
                    console.log("Model=> ", $model);
                    //Test CoreJs
                    $.CoreJs().Test();
                }

            });

        }

    }
}