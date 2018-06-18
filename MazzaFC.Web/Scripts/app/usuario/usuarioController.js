appmazzafc.controller("usuarioController", ['$scope', '$window', 'usuarioRepository', function ($scope, $window, usuarioRepository) {

    listar();

    function listar() {

        usuarioRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaUsuarios = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }

    }

    $scope.novo = function () {
        $scope.UsuarioId = null;
        $scope.UsuarioNome = "";
        $scope.UsuarioSenha = "";
        $scope.UsuarioEmail = "";
    }

    $scope.salvar = function () {

        var _model = {
            "UsuarioId": $scope.UsuarioId,
            "UsuarioNome": $scope.UsuarioNome,
            "UsuarioSenha": $scope.UsuarioSenha,
            "UsuarioEmail": $scope.UsuarioEmail
        }

        usuarioRepository.salvar(_model).then(sucesso, fail);

        function sucesso(response) {

            alert(response.data.Mensagem);

            listar();

            $("#modalForm").modal("hide");
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }
    }

    $scope.editar = function (item) {

        $scope.UsuarioId = item.UsuarioId;
        $scope.UsuarioNome = item.UsuarioNome;
        $scope.UsuarioSenha = item.UsuarioSenha;
        $scope.UsuarioEmail = item.UsuarioEmail;

        $("#modalForm").modal();
    }

    $scope.excluir = function (item) {

        usuarioRepository.excluir(item).then(sucesso, fail);

        function sucesso(response) {

            alert(response.data.Mensagem);

            listar();
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }
    }

}]);