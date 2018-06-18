appmazzafc.controller("medicoController", ['$scope', '$window', 'medicoRepository', function ($scope, $window, medicoRepository) {

    listar();

    function listar() {

        medicoRepository.listar().then(sucesso, fail);

        function sucesso(response) {
            $scope.listaMedicos = response.data;
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }

    }

    $scope.novo = function () {
        $scope.MedicoId = null;
        $scope.MedicoEspecialidade = "";
        $scope.MedicoCRM = "";
        $scope.PessoaDocumento = "";
        $scope.PessoaNome = "";
        $scope.PessoaDataNascimento = "";
        $scope.PessoaRG = "";        
    }

    $scope.salvar = function () {

        var _model = {
            "MedicoId": $scope.MedicoId,
            "MedicoEspecialidade": $scope.MedicoEspecialidade,
            "MedicoCRM": $scope.MedicoCRM,
            "Pessoa.PessoaDocumento": $scope.PessoaDocumento,
            "Pessoa.PessoaNome": $scope.PessoaNome,
            "Pessoa.PessoaDataNascimento": $scope.PessoaDataNascimento,
            "Pessoa.PessoaRG": $scope.PessoaRG
        }

        medicoRepository.salvar(_model).then(sucesso, fail);

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

        console.log(item);

        $scope.MedicoId = item.MedicoId;
        $scope.MedicoEspecialidade = item.MedicoEspecialidade;
        $scope.MedicoCRM = item.MedicoCRM;
        $scope.PessoaDocumento = item.Pessoa.PessoaDocumento;
        $scope.PessoaNome = item.Pessoa.PessoaNome;
        $scope.PessoaDataNascimento = item.Pessoa.PessoaDataNascimento;
        $scope.PessoaRG = item.Pessoa.PessoaRG;
        

        $("#modalForm").modal();
    }

    $scope.excluir = function (item) {

        medicoRepository.excluir(item).then(sucesso, fail);

        function sucesso(response) {

            alert(response.data.Mensagem);

            listar();
        };

        function fail(error) {
            alert("Erro ao processar!!");
        }
    }

}]);