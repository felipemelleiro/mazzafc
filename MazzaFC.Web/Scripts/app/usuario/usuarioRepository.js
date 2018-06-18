appmazzafc.factory("usuarioRepository", function ($http) {

    var baseUrl = '';

    return {

        listar: function () {
            return $http({
                method: 'get',
                url: baseUrl + '/usuario/listar',
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        salvar: function (modelUsuario) {
            return $http({
                method: 'post',
                url: baseUrl + '/usuario/salvar',
                params: modelUsuario,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        excluir: function (modelUsuario) {
            return $http({
                method: 'post',
                url: baseUrl + '/usuario/excluir',
                params: modelUsuario,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        }

    };

});