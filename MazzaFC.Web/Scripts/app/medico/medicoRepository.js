appmazzafc.factory("medicoRepository", function ($http) {

    var baseUrl = '';

    return {

        listar: function () {
            return $http({
                method: 'get',
                url: baseUrl + '/medico/listar',
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        salvar: function (modelMedico) {
            return $http({
                method: 'post',
                url: baseUrl + '/medico/salvar',
                params: modelMedico,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        excluir: function (modelMedico) {
            return $http({
                method: 'post',
                url: baseUrl + '/medico/excluir',
                params: modelMedico,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        }

    };

});