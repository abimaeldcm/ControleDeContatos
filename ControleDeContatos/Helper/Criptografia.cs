using System.Runtime.Intrinsics.X86;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ControleDeContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor) //Sempre que tver uma string eu vou poder chamar o gerarhash
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach ( var item in array ) 
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}

// Explicação:
/*Esse código é uma classe estática chamada Criptografia, que contém um método de extensão chamado GerarHash. O método GerarHash é usado para gerar um hash SHA-1 a partir de uma string fornecida como entrada.

Vamos entender o que cada parte do código faz:

public static class Criptografia : Isso define a classe Criptografia como uma classe estática, o que significa que não é necessário instanciar um objeto dela para acessar seus membros.O uso de uma classe estática permite que o método de extensão seja chamado diretamente na instância de string.

public static string GerarHash(this string valor): Isso declara o método de extensão GerarHash, que pode ser chamado em uma instância de string. O método recebe uma string como parâmetro e retorna um string.

var hash = SHA1.Create();: Isso cria uma instância do algoritmo de hash SHA-1.

var encoding = new ASCIIEncoding();: Isso cria uma instância da classe ASCIIEncoding, que é usada para converter a string em um array de bytes ASCII.

var array = encoding.GetBytes(valor);: Isso converte a string fornecida (valor) em um array de bytes usando a codificação ASCII.

array = hash.ComputeHash(array);: Isso calcula o hash SHA-1 do array de bytes usando o algoritmo SHA-1 criado anteriormente.

var strHexa = new StringBuilder();: Isso cria uma instância de StringBuilder para construir a representação hexadecimal do hash.

foreach (var item in array): Isso inicia um loop para iterar por cada byte no array do hash calculado.

strHexa.Append(item.ToString("x2"));: Dentro do loop, cada byte do hash é convertido para uma representação hexadecimal de dois dígitos e adicionado ao StringBuilder.

return strHexa.ToString();: Finalmente, o método retorna a representação hexadecimal completa do hash como uma string.

Em resumo, esse código é um método de extensão que permite calcular o hash SHA-1 de uma string usando a classe Criptografia. O hash é retornado como uma string representando a sequência hexadecimal resultante. Esse tipo de funcionalidade é útil para proteger senhas ou criar valores únicos para identificação de dados.*/
