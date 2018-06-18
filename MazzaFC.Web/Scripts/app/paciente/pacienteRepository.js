appmazzafc.factory("pacienteRepository", function ($http) {

    var baseUrl = '';

    return {

        listar: function () {
            return $http({
                method: 'get',
                url: baseUrl + '/paciente/listar',
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        salvar: function (modelPaciente) {
            return $http({
                method: 'post',
                url: baseUrl + '/paciente/salvar',
                params: modelPaciente,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        }

    };

});