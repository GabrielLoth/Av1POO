using System;
using System.Collections.Generic;

abstract class Canal
{
    public abstract void EnviarMensagem(Mensagem mensagem);
}

class WhatsApp : Canal
{
    private string numero;
    public WhatsApp(string numero) { this.numero = numero; }

    public override void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"[WhatsApp - {numero}]");
        mensagem.Exibir();
    }
}

class Telegram : Canal
{
    private string identificador;
    public Telegram(string identificador) { this.identificador = identificador; }

    public override void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"[Telegram - {identificador}]");
        mensagem.Exibir();
    }
}

class Facebook : Canal
{
    private string usuario;
    public Facebook(string usuario) { this.usuario = usuario; }

    public override void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"[Facebook - {usuario}]");
        mensagem.Exibir();
    }
}

class Instagram : Canal
{
    private string usuario;
    public Instagram(string usuario) { this.usuario = usuario; }

    public override void EnviarMensagem(Mensagem mensagem)
    {
        Console.WriteLine($"[Instagram - {usuario}]");
        mensagem.Exibir();
    }
}

abstract class Mensagem
{
    public string Texto { get; set; }
    public abstract void Exibir();
}

class Texto : Mensagem
{
    public DateTime DataEnvio { get; set; }

    public override void Exibir()
    {
        Console.WriteLine($"[Texto] Mensagem: {Texto}, Enviada em: {DataEnvio}");
    }
}

class Video : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }
    public double Duracao { get; set; }

    public override void Exibir()
    {
        Console.WriteLine($"[Vídeo] Mensagem: {Texto}, Arquivo: {Arquivo}, Formato: {Formato}, Duração: {Duracao} segundos");
    }
}

class Foto : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }

    public override void Exibir()
    {
        Console.WriteLine($"[Foto] Mensagem: {Texto}, Arquivo: {Arquivo}, Formato: {Formato}");
    }
}

class Arquivo : Mensagem
{
    public string ArquivoNome { get; set; }
    public string Formato { get; set; }

    public override void Exibir()
    {
        Console.WriteLine($"[Arquivo] Mensagem: {Texto}, Arquivo: {ArquivoNome}, Formato: {Formato}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Canal> canais = new List<Canal>
        {
            new WhatsApp("+551199999999"),
            new Telegram("usuario_telegram"),
            new Facebook("usuario_fb"),
            new Instagram("usuario_insta")
        };

        Mensagem msgTexto = new Texto { Texto = "Olá mundo!", DataEnvio = DateTime.Now };
        Mensagem msgVideo = new Video { Texto = "Veja isso", Arquivo = "video.mp4", Formato = "mp4", Duracao = 15.5 };
        Mensagem msgFoto = new Foto { Texto = "Olha essa foto", Arquivo = "foto.jpg", Formato = "jpg" };
        Mensagem msgArquivo = new Arquivo { Texto = "Segue o arquivo", ArquivoNome = "relatorio.pdf", Formato = "pdf" };

        foreach (var canal in canais)
        {
            canal.EnviarMensagem(msgTexto);
            canal.EnviarMensagem(msgVideo);
            canal.EnviarMensagem(msgFoto);
            canal.EnviarMensagem(msgArquivo);
            Console.WriteLine();
        }
    }
}
