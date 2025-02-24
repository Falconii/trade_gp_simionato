// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Conexaodb
{
    public string app_text { get; set; }
    public StringConection string_conection { get; set; }
}

public class Conexao
{
    public Conexaodb conexaodb { get; set; }
}

public class StringConection
{
    public string Server { get; set; }
    public string Port { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
    public string CommandTimeout { get; set; }
}

