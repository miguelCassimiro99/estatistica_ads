using System;

namespace Algoritmo_Estatistica
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtd_lin = 20, qtd_col = 50; //definindo extensão dos dados
            int[,] nAmostral = new int[qtd_lin, qtd_col]; //matriz principal que receberá os valores randomicos
            double media, mediana, moda, DesvP, cVar; //valores que o usuário podera consultar
            int maior, menor, amplAm, ampl;
            int n = (qtd_col * qtd_lin); // numero total de valores
            double d = Math.Log(n); //log1000;
            double i = 1 + (3.3*d); //calculando o numero de classes

            Console.WriteLine("ALGORITMO DE ESTATISTICA");
            Console.WriteLine();
            
            //Criação da Tabela e exibição
            nAmostral = Alimenta(qtd_lin, qtd_col); //funcão que alimenta matriz que conterá os numeros aleatorios
            exibirTabela(nAmostral); //funcao que exibe a tabela. para uma visualização dinamica é necessário aumento da tela
            //

            maior = ValMax(nAmostral); //funcao que retorna o valor máximo da tabela
            menor = ValMin(nAmostral, maior); // funcao que rertorna o menor numero da matriz
            amplAm = maior - menor; // atribuindo a variavel o valor da Amplitude amostral
            double h = amplAm / i; // calculo da amplitude
            int numClass = Convert.ToInt32(i);
            ampl = Convert.ToInt32(h);


            int[] l = new int[numClass]; //vetor que conterá o l de cada intervalo de Classes

            l = Lmin(numClass, menor, ampl); //atribuindo valor de l

            //exibição de dados
            Console.WriteLine("Exibindo Dados da Tabela: ");
            Console.WriteLine("\n\nn = {0}", n);
            Console.WriteLine("Maior valor: {0}", maior);
            Console.WriteLine("Menor valor: {0}", menor);
            Console.WriteLine("i = {0:N0}", i);
            Console.WriteLine("Amplitude Amostral = {0:N0}", amplAm);
            Console.WriteLine("h = {0:N0}", h);
            //

            Console.WriteLine("\n\nPressione ENTER para continuar \n");
            Console.ReadKey();
            Console.Clear();

            //exibindo divisão de classes caso seja necessário uso para estudo e demais calculos
            Console.WriteLine("Divisão das Classes: \n");
            Console.WriteLine(" i      l      L");
            for (int s = 0; s < numClass; s++)
            {
                Console.WriteLine("{0:N0}      {1}      {2}", i, l[s], l[s]+ampl);
            }
            //
            Console.WriteLine();
            Console.WriteLine();

            int op; //variavel que contera a opção selecionada pelo usuario para consulta de daods
            bool t = true;
            while (t = true) //condição responsavel por permitir que o usuario consulte mais de um valor da mesma tabela
            {
                //usuario seleciona qual tipo valor deseja consultar
                Console.WriteLine("1 - Média ");
                Console.WriteLine("2 - Moda ");
                Console.WriteLine("3 - Mediana ");
                Console.WriteLine("4 - Desvio Padrão ");
                Console.WriteLine("5 - Coeficiente de Variação ");
                Console.WriteLine("\n\nDigite a Opção desejada: ");
                op = int.Parse(Console.ReadLine());


                int[] vetOrg = new int[qtd_lin * qtd_col]; //vetor que armazena valores da tabela
                vetOrg = Organiza(nAmostral); //jogando valores da tabela na matriz
                Console.WriteLine();
                Array.Sort(vetOrg); //ordenando vetor
                media = Media(nAmostral, qtd_lin, qtd_col); //funcão que retorna a media e armazena na variavel correspondente
                DesvP = DesvPad(vetOrg, media, n); //funcao que retorna desvio padrao e retorna para a varial correspondente

                //apresentação das opçoes desejadas
                switch (op)
                {
                    case 1:

                        Console.WriteLine("Média: {0:N2}", media);
                        Console.WriteLine("\nPrecione ENTER para continuar... ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        moda = Moda(nAmostral, qtd_lin, qtd_col); //atribui a moda a variavel correspondente atraves da funcão 'Moda'
                        Console.WriteLine("Moda: {0}", moda);
                        Console.WriteLine("\nPrecione ENTER para continuar... ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        mediana = (vetOrg[499] + vetOrg[500]) / 2; //realiza calculo da mediana e atribui o resultado a variavel mediana
                        Console.WriteLine("Mediana: {0:N2}", mediana);
                        Console.WriteLine("\nPrecione ENTER para continuar... ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:

                        DesvP = Math.Sqrt((DesvP / n)); //coleta do valor retornado pela função e realizado calculo do desvio padrão
                        Console.WriteLine("Desvio Padrão: {0:N2}", DesvP);
                        Console.WriteLine("\nPrecione ENTER para continuar... ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        cVar = (DesvP / media) * 100; //calculo do coeficiente de variação
                        Console.WriteLine("Coeficiente de Variação: {0:N2}", cVar);
                        Console.WriteLine("\nPrecione ENTER para continuar... ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Nenhuma das Opções foram digitadas... BYE BYE"); //fecha a aplicação caso o usuario nao digite nenhuma opção mostrada
                        Console.ReadKey();
                        Console.Clear();
                        Environment.Exit(0);
                        t = false;
                        break;

                 }
            }
            
        }
        //inicio dos metodos utilizados
        static int[,] Alimenta(int nlin, int ncol) //funcao que alimenta a matriz principal com numeros aleatorios de uma a 100
        {
            int[,] matriz = new int[nlin, ncol];
            Random random = new Random();

            for (int i = 0; i < nlin; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    matriz[i, j] = random.Next(1, 101);
                }
            }
            return matriz;


        }

        static void exibirTabela(int[,] matriz) //funcao responsavel pela exibição da matriz
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {

                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if(matriz[i,j] < 10)
                    {
                        Console.Write("0" + matriz[i, j] + " ");
                    }
                    if(matriz[i,j] >=10 && matriz[i,j] < 100)
                    {
                        Console.Write("" + matriz[i, j] + " ");
                    }
                 
                }
                Console.WriteLine();
            }
        }

        static int ValMax(int[,] tabela) //funcao que retorna o valor maximo presente
        {
            int max=0;
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (tabela[i, j] > max)
                    {
                        max = tabela[i, j];
                    }
                }
            }
            return max;
        }

        static int ValMin(int[,] tabela1, int max) // funcao que retorna o valor minimo
        {
            int min = max;
            for(int i = 0; i < tabela1.GetLength(0); i++)
            {
                for (int j = 0; j < tabela1.GetLength(1); j++)
                {
                    if (tabela1[i, j] < max)
                    {
                        min = tabela1[i, j];
                        max = tabela1[i, j];
                    }
                }
            }
            return min;
        }

        static int[] Lmin(int classes, int MenVal, int Amplitude) //funcao que calcula o l min
        {
            int[] Lmenor = new int[classes];

            for(int i = 0; i < classes; i++)
            {
                Lmenor[i] = MenVal + Amplitude;
                MenVal = MenVal + Amplitude;
            }
            return Lmenor;
        }

        static double Media(int[,] m1, int lin, int col) //funcao que calcula a media
        {
            double soma = 0, media;
            for(int i=0;i<m1.GetLength(0); i++)
            {
                for(int j = 0; j < m1.GetLength(1); j++)
                {
                    soma = soma + m1[i, j];
                }
            }
            media = soma/(lin*col);
            return media;
        }

        static int[] Organiza(int[,] m2) //funcao que armazena dados da matriz no vetor
        {
            int[] vet = new int[1000];
            int cont = 0;
            for(int i = 0; i < m2.GetLength(0); i++)
            {
                for(int j = 0; j < m2.GetLength(1); j++)
                {
                    vet[cont] = m2[i, j];
                    cont = cont+1;
                }
                
            }
            return vet;
        }

        static double DesvPad(int[]vetor, double med, int n)
        {
            double[] soma = new double[n];
            double SomaVet = 0 ;
            for(int i = 0; i < vetor.GetLength(0); i++)
            {
                soma[i] = Math.Pow((vetor[i] - med),2);
                SomaVet = SomaVet + soma[i];
            }
            return SomaVet;
        } // funcao responsavel por calcular o desvio padrao

        static int Moda(int[,] m3, int lin, int col)
        {
            int[] mo = new int[100];
            int grd, mar = 0, mnr = 0, moda = 0;
            for(int i=0; i < 100; i++)
            {
                grd = 0;
                for(int l = 0; l < lin; l++)
                {
                    for(int f = 0; f < col; f++)
                    {
                        if(m3[l,f] == i)
                        {
                            mo[i] = grd++;
                        }
                        if (mar < grd)
                        {
                            mar = grd;
                            moda = i;
                        }
                    }
                }
                
            }
            return moda;
        } //funcao responsavel por calcular a moda
    }
}
