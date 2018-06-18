appmazzafc.controller("pacienteController", ['$scope', '$window', 'pacienteRepository', function ($scope, $window, pacienteRepository) {

    listar();

    function listar() {

        pacienteRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaMedicos = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }

    }

    $scope.novo = function () {
        $scope.PacienteId = null;
        $scope.PacientePlanoSaude = "";
        $scope.PessoaDocumento = "";
        $scope.PessoaNome = "";
        $scope.PessoaDataNascimento = "";
        $scope.PessoaRG = "";
    }

    $scope.salvar = function () {

        var _model = {
            "PacienteId": $scope.PacienteId,
            "PacientePlanoSaude": $scope.PacientePlanoSaude,
            "Pessoa.PessoaDocumento": $scope.PessoaDocumento,
            "Pessoa.PessoaNome": $scope.PessoaNome,
            "Pessoa.PessoaDataNascimento": $scope.PessoaDataNascimento,
            "Pessoa.PessoaRG": $scope.PessoaRG
        }

        pacienteRepository.salvar(_model).then(sucesso, fail);

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

        $scope.PacienteId = item.PacienteId;
        $scope.PessoaDocumento = item.Pessoa.PessoaDocumento;
        $scope.PessoaNome = item.Pessoa.PessoaNome;
        $scope.PessoaDataNascimento = item.Pessoa.PessoaDataNascimento;
        $scope.PessoaRG = item.Pessoa.PessoaRG;
        $scope.PacientePlanoSaude = item.PacientePlanoSaude;

        $("#modalForm").modal();
    }

    

}]);