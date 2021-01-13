namespace MediatrTesteConsoleApp
{
    public class Servico1 : IServico1
    {
        private readonly IServico2 servico2;

        public Servico1(IServico2 servico2)
        {
            this.servico2 = servico2;
        }

        public void Teste(int num)
        {
            int num1 = 6;
            var resultado = this.servico2.Sum(num1, num);

            /*...business code ... */
        }

    }


}
