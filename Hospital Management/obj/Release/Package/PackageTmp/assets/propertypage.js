// State Filter By District
    $('#drpruralstate').change(function () {
        var Id = $('#drpruralstate').val('');
        if (Id != "") {
            $.ajax({
                url: '/Admin/GetAllDistrict',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ Id: Id }),
                async: true,
                processData: false,
                cache: false,
                success: FillSubject,
                error: function (xhr) {
                }
            });
        }
    });

    function FillSubject(result) {
        var StateList = result.StateList;
        var select = $("#drpruraldist");
        if (select != null) {
            select.empty();
            select.append($('<option/>', {
                value: "",
                text: "Select District"
            }));
            for (i = 0; i < StateList.length; i++) {
                select.append($('<option/>', {
                    value: StateList[i].DISTRICT_CODE,
                    text: StateList[i].DISTRICT_NAME
                }));
            }
        }
    }

// District Filter By SubDistrtic


    $('#drpruraldist').change(function () {

        var Id = $('#drpruraldist').val();
        if (Id != "") {
            $.ajax({
                url: '/Admin/GetAllSubDistrict',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ Id: Id }),
                async: true,
                processData: false,
                cache: false,
                success: FillSubject,
                error: function (xhr) {
                }
            });
        }
    });

    function FillSubject(resultsub) {
        var SubDistrictList = resultsub.SubDistrictList;
        var select = $("#drpruralsubdist");
        if (select != null) {
            select.empty();
            select.append($('<option/>', {
                value: "",
                text: "Select Sub District"
            }));
            for (i = 0; i < SubDistrictList.length; i++) {
                select.append($('<option/>', {
                    value: SubDistrictList[i].SUB_DISTRICT_CODE,
                    text: SubDistrictList[i].SUB_DISTRICT_NAME
                }));
            }
        }
    }

// Town / Village Filter By SubDistrict 

    $('#drpruralsubdist').change(function () {
        
        var SubId = $('#drpruralsubdist').val();
        var RId = $('#drppropfallsunder').val();
        if (SubId != "") {
            $.ajax({
                url: '/Admin/GetByTownVillag_SubDistrict_Wise',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ SubId: SubId, RId: RId }),
                async: true,
                processData: false,
                cache: false,
                success: FillSubject,
                error: function (xhr) {
                }
            });
        }
        function FillSubject(result) {
            var RularurbanList = result.RularurbanList;
            var select = $("#drptown");
            if (select != null) {
                select.empty();
                select.append($('<option/>', {
                    value: "",
                    text: "Select Town/Village"

                }));

                for (i = 0; i < RularurbanList.length; i++) {
                    select.append($('<option/>', {
                        value: RularurbanList[i].Id,
                        text: RularurbanList[i].TownName
                    }));
                }
            }
        }
    });


// Change Status 
    $('#drpstatus').change(function () {
        var modeVB = $("#drpstatus").val();
        var modeVB;
        if (modeVB == '1' || modeVB == '2') {
            $("#namepropety").show();
            $("#mobile").show();
        }
        else {
            $("#namepropety").hide();
            $("#mobile").hide();
            $('#namepropety').prop("required", false);
            $('#mobile').prop("required", false);
            document.getElementById("namepropety").style.display = "none";
            document.getElementById("mobile").style.display = "none";

        }
    });
// change Uint


    document.getElementById("subunit").style.display = 'none';
    document.getElementById("namepropety").style.display = 'none';
    document.getElementById("mobile").style.display = 'none';
    $('#drpunit').change(function () {

        var mode = $('#drpunit').val();
        var modevalue;
        if (mode == '5') {
            $("#subunit").show();
        }
        else {
            $("#subunit").hide();

        }
    });


/// Rular Urban

    document.getElementById("rural").style.display = 'show';
    document.getElementById("urban").style.display = 'show';
    $('#drppropfallsunder').change(function () {
        
        var mode = $('#drppropfallsunder').val();
        if (mode != "") {
            $.ajax({
                url: '/Admin/TownVillag',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ mode: mode }),
                async: true,
                processData: false,
                cache: false,
                success: FillSubject,
                error: function (xhr) {
                }
            });
        }
        function FillSubject(result) {
            var RularurbanList = result.RularurbanList;
            var select = $("#drptown");
            if (select != null) {
                select.empty();
                select.append($('<option/>', {
                    value: "",
                    text: "Select Town/Village"
                }));

                for (i = 0; i < RularurbanList.length; i++) {
                    select.append($('<option/>', {
                        value: RularurbanList[i].Id,
                        text: RularurbanList[i].TownName
                    }));
                }
            }
        }
        var modevalue;
        if (mode == '1') {
            $("#rural").show();
            $("#urban").hide();

        }

        else if (mode == '2') {
            $("#rural").hide();
            $("#urban").show();

        }
    });