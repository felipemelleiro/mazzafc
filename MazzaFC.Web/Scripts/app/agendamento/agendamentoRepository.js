appmazzafc.factory("agendamentoRepository", function ($http) {

    var baseUrl = '';

    return {

        listar: function () {
            return $http({
                method: 'get',
                url: baseUrl + '/agendamento/listar',
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        salvar: function (modelUsuario) {
            return $http({
                method: 'post',
                url: baseUrl + '/agendamento/salvar',
                params: modelUsuario,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        excluir: function (modelUsuario) {
            return $http({
                method: 'post',
                url: baseUrl + '/agendamento/excluir',
                params: modelUsuario,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        }

    };

});