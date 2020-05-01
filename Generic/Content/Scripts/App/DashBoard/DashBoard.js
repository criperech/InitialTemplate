let DashBoard = function ($model) {

    return {

        Load: function () {

            let DashBoardApp = new Vue({
                el: "#dashboard-module",
                data: {
                    test: "Vue Works"

                },
                mounted: function () {

                    //Test CoreJs
                    $.CoreJs().Test();
                }

            });

        }

    }
}