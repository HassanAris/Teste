$.CarroAPI = function () {
    return {
        urlListar: '/Controlles/Carro/Listar',

        Init: function () {
            this.UI.BindAll();
        },

        UI: {
            BindAll: function () {
                this.Tabela('#tblCarro', $.CarroAPI.urlListar);
            },
            Tabela: function (seletor, url) {
                $(seletor).dataTable({
                    "sDom": '<"top">rt<"bottom"ip><"clear">',
                    "bServerSide": true,
                    "sAjaxSource": url,
                    "scrollX": true,
                    "bProcessing": true,
                    "oLanguage": {
                        "sUrl": "/Scripts/plugins/datatables/jquery.datatables.pt-br.txt"
                    },
                    "pagingType": "bootstrap_full_number",
                    "fnInitComplete": function (oSettings, json) {
                        $(seletor).find('input').addClass('form-control').addClass('input-medium');
                        $(seletor).find('select').addClass('form-control').addClass('input-small');
                    },
                    "fnCreatedRow": function (nRow, aData, iDataIndex) {
                        $(nRow).data('id', aData[0]);
                        $(nRow).data('nome', aData[1]);
                    },
                    "aoColumns": [
                        {
                            "bSortable": false,
                            "sName": "Id",
                            "mRender": function (data, type, full) {
                                return '<input class="checker rdPlanoRemuneracao" type="radio" value="' + data + '" style="opacity: 0" name="selected_planoRemuneracao" align="middle">';
                            },
                            "fnCreatedCell": function (ntd, sData, oData, iRow, iCol) {
                                $(ntd).find('input').uniform();
                            }
                        },
                        { "sName": "Id" },
                        { "sName": "Carro" }
                    ]
                });
            },
            Uniform: function () {

            },
           
        },

        Events: {
            BindAll: function () {

            },
            BindAcompanhar: function () {
             
            },

        },

        Methods: {
        }
    }
}();