namespace CIPA.Models;

// Classe que representa o modelo de dados para a página de erro
public class ErrorViewModel
{
    // Identificador único da requisição que causou o erro
    // Pode ser nulo se o ID não estiver disponível
    public string? RequestId { get; set; }

    // Propriedade que indica se o RequestId deve ser exibido na View
    // Retorna true se o RequestId não for nulo ou vazio
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}