// Models/Candidato.cs
namespace CIPA.Models
{
    public class Candidato
    {
        // Identificador único do candidato
        public int Id { get; set; }

        // Nome do candidato (inicializado como string vazia para evitar valores nulos)
        public string Nome { get; set; } = string.Empty;

        // Campo privado para armazenar o número do partido
        private int _numeroPartido;

        // Propriedade pública para acessar e validar o número do partido
        public int NumeroPartido
        {
            get => _numeroPartido; // Retorna o valor atual do número do partido
            set
            {
                // Valida se o número do partido tem exatamente 4 dígitos
                if (value.ToString().Length != 4)
                {
                    throw new ArgumentException("O número do partido deve ter exatamente 4 dígitos.");
                }
                // Atribui o valor válido ao campo privado
                _numeroPartido = value;
            }
        }

        // Contagem de votos recebidos pelo candidato
        public int Votos { get; set; }
    }
}

// Models/Eleitor.cs
namespace CIPA.Models
{
    public class Eleitor
    {
        // Identificador único do eleitor
        public int Id { get; set; }

        // Nome do eleitor (permite valores nulos)
        public string? Nome { get; set; }

        // CPF do eleitor (permite valores nulos)
        public string? CPF { get; set; }

        // Indica se o eleitor já votou (false = não votou, true = votou)
        public bool Votou { get; set; }
    }
}