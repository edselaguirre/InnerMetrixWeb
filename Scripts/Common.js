$(document).ready(function () {
    //toastr.error(text);
    //toastr.success(text); 

    //jQuery.validator.addMethod("emailfull", function (value, element) {
    //    return this.optional(element) || /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i.test(value);
    //}, "Please enter valid email address!");

    //$("form").validate({
    //    rules: {
    //        field: {
    //            required: true,
    //            emailfull: true
    //        }
    //    }
    //});

    $("form").submit(function (event) {
        localStorage.clear();
    });

    $(function () {
        //toastr.error($("#uid").val() + " " + $("#OracleId").val());
        if ($("#UserName").val() != "" && $("#OracleId").val() != "") {
            $("#Password").removeAttr("disabled");
            $("#submitbtn").removeAttr("disabled");
        }
    });

    $(document).ajaxStart(function () {
        $("#wait").css("display", "block");
    });
    $(document).ajaxComplete(function () {
        $("#wait").css("display", "none");
    });

    $("#OracleId").on("blur", function () {
        var oracleId = localStorage.getItem("OracleId");
        if (oracleId != "") {
            if (oracleId != $("#OracleId").val() || $("#UserName").val() == "") {
                //toastr.error("Oracle Id has been change, Please search user.");
                $("#Password").attr("disabled", "disabled");
                $("#submitbtn").attr("disabled", "disabled");
                $(".validation-summary-errors ul").empty();
                $(".validation-summary-errors ul").append("<li>Oracle Id is required.</li>");
            } else {
                $("#Password").removeAttr("disabled");
                $("#submitbtn").removeAttr("disabled");
            }
        }
    });









    $("#btnSubmit").on("click", function () {        
        $("#pbUpload").css("visibility", "visible"); 
        $("#aInfo").css("visibility", "visible");
        alert("test");
    });





    $("#btnCheckOracleId").on("click", function () {
        //console.log($("#OracleId").val());
        $("#Password").attr("disabled", "disabled");
        $("#submitbtn").attr("disabled", "disabled", );

        if ($("#OracleId").val() != "") {
            $.getJSON({ url: config.contextPath + "Home/GetGuestInfo" }, {
                "OracleId": $("#OracleId").val()
            }, function (resp) {
                if (resp != "") {
                    localStorage.setItem("OracleId", $("#OracleId").val());
                    $("#UserName").val(resp["uid"]);
                    $("#FirstName").val(resp["FirstName"]);
                    $("#LastName").val(resp["LastName"]);
                    $("#EmailAddress").val(resp["EmailAddress"]);

                    $("#Password").val("");
                    $("#Password").removeAttr("disabled");
                    $("#submitbtn").removeAttr("disabled");

                    $(".validation-summary-errors ul").empty();
                    $(".validation-summary-valid ul").empty();

                    toastr.success("Hello " + resp["FirstName"] + "!");
                } else {
                    //toastr.error("Invalid User Id, Please retry!");
                    $(".validation-summary-errors ul").empty();
                    $(".validation-summary-errors ul").append("<li>User ID not found. Try again.</li>");

                    $(".validation-summary-valid ul").empty();
                    $(".validation-summary-valid ul").append("<li>User ID not found. Try again.</li>");
                }
            }).done(function (result, status, xhr) {
                //alert("User found - " + result["FirstName"] + " " + result["LastName"]);
            }).fail(function (xhr, status, error) {
                //toastr.error("Invalid User Id, Please retry!");
                $(".validation-summary-errors ul").empty();
                $(".validation-summary-errors ul").append("<li>User ID not found. Try again.</li>");

                $(".validation-summary-valid ul").empty();
                $(".validation-summary-valid ul").append("<li>User ID not found. Try again.</li>");
                //toastr.error("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            });
        } else {
            //toastr.error("Please enter Oracle Id.");
            $(".validation-summary-errors ul").empty();
            $(".validation-summary-errors ul").append("<li>Oracle ID is required.</li>");

            $(".validation-summary-valid ul").empty();
            $(".validation-summary-valid ul").append("<li>Oracle ID is required.</li>");
        }
    });
});