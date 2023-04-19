using iTextSharp.text;
using iTextSharp.text.pdf;


namespace CriarPDFCurriculo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma instância de um objeto Document
            Document doc = new Document();

            try
            {
                // Cria uma instância de um objeto PdfWriter para gravar o documento em um arquivo
                PdfWriter.GetInstance(doc, new FileStream("curriculo.pdf", FileMode.Create));

                // Abre o documento
                doc.Open();

                // Adiciona o título do currículo
                Font fontTitulo = new Font(Font.FontFamily.HELVETICA, 24, Font.BOLD, BaseColor.BLACK);
                Paragraph titulo = new Paragraph("Currículo", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20f;
                doc.Add(titulo);

                // Adiciona a seção de informações pessoais
                Font fontCabecalho = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, BaseColor.BLACK);
                Font fontTexto = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK);

                Paragraph cabecalho = new Paragraph("Informações pessoais", fontCabecalho);
                cabecalho.SpacingAfter = 10f;
                doc.Add(cabecalho);

                PdfPTable tabelaInfo = new PdfPTable(2);
                tabelaInfo.WidthPercentage = 100f;
                tabelaInfo.SpacingAfter = 20f;

                tabelaInfo.AddCell(new PdfPCell(new Phrase("Nome completo:", fontTexto)));
                tabelaInfo.AddCell(new PdfPCell(new Phrase("João da Silva", fontTexto)));

                tabelaInfo.AddCell(new PdfPCell(new Phrase("E-mail:", fontTexto)));
                tabelaInfo.AddCell(new PdfPCell(new Phrase("joao.silva@gmail.com", fontTexto)));

                tabelaInfo.AddCell(new PdfPCell(new Phrase("Telefone:", fontTexto)));
                tabelaInfo.AddCell(new PdfPCell(new Phrase("(11) 99999-9999", fontTexto)));

                tabelaInfo.AddCell(new PdfPCell(new Phrase("Endereço:", fontTexto)));
                tabelaInfo.AddCell(new PdfPCell(new Phrase("Rua dos Bobos, 0 - São Paulo/SP", fontTexto)));

                doc.Add(tabelaInfo);

                // Adiciona a seção de formação acadêmica
                Paragraph formacao = new Paragraph("Formação acadêmica", fontCabecalho);
                formacao.SpacingAfter = 10f;
                doc.Add(formacao);

                PdfPTable tabelaFormacao = new PdfPTable(3);
                tabelaFormacao.WidthPercentage = 100f;
                tabelaFormacao.SpacingAfter = 20f;

                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Curso", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Instituição", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Conclusão", fontTexto)));

                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Graduação em Engenharia Civil", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Universidade de São Paulo", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Dez/2019", fontTexto)));

                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Mestrado em Administração de Empresas", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("Fundação Getúlio Vargas", fontTexto)));
                tabelaFormacao.AddCell(new PdfPCell(new Phrase("2015 - 2017", fontTexto)));
                tabelaFormacao.HorizontalAlignment = 0;
                doc.Add(tabelaFormacao);
                

                // Adiciona a seção de experiência profissional
            
                Paragraph experiencia = new Paragraph("Formação acadêmica", fontCabecalho);
                experiencia.SpacingAfter = 10f;
                doc.Add(experiencia);

                PdfPTable tabelaExperiencia = new PdfPTable(3);
                tabelaExperiencia.WidthPercentage = 100f;
                tabelaExperiencia.SpacingAfter = 20f;

                // Cria uma tabela para listar as experiências profissionais
                
                tabelaExperiencia.WidthPercentage = 100;
                tabelaExperiencia.DefaultCell.Padding = 10;
                tabelaExperiencia.DefaultCell.BorderWidth = 0;

                // Adiciona as colunas da tabela
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Empresa", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Cargo", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Período", fontTexto)));

                // Adiciona as linhas da tabela com exemplos aleatórios
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Empresa X", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Analista de Marketing", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("2019 - 2022", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Empresa Y", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("Coordenador de Vendas", fontTexto)));
                tabelaExperiencia.AddCell(new PdfPCell(new Phrase("2017 - 2019", fontTexto)));
                tabelaExperiencia.HorizontalAlignment = 0;
                doc.Add(tabelaExperiencia);
                

                // Adiciona a seção de habilidades
                doc.Add(new Paragraph("Habilidades", fontCabecalho));
    

                // Cria uma lista com as habilidades
                List listaHabilidades = new List(List.UNORDERED);
                listaHabilidades.SetListSymbol("\u2022"); // Define o símbolo da lista
                listaHabilidades.IndentationLeft = 30;
                listaHabilidades.IndentationRight = 30;
                
                // Adiciona exemplos aleatórios de habilidades
                listaHabilidades.Add(new ListItem("Habilidade 1", fontTexto));
                listaHabilidades.Add(new ListItem("Habilidade 2", fontTexto));
                listaHabilidades.Add(new ListItem("Habilidade 3", fontTexto));
                listaHabilidades.Add(new ListItem("Habilidade 4", fontTexto));
                listaHabilidades.Add(new ListItem("Habilidade 5", fontTexto));
                listaHabilidades.Add(new ListItem("Habilidade 6", fontTexto));

                doc.Add(listaHabilidades);

                // Fecha o documento
                doc.Close();}
                
                   catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("PDF gerado com sucesso.");
                Console.ReadKey();
            }}}}

