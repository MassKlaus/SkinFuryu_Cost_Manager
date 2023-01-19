using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;

namespace SkinFuryu.CostManager.Infrastructure.FilePrinters
{
    public class PdfPrinter : IFormulaPrinter
    {
        private const string Template = @".\Template\Template.html";
        public CultureInfo Culture { get; set; } = CultureInfo.GetCultureInfo("en-PH");


        public void PrintFile(FormulaReport formulaReport)
        {
            string template = File.ReadAllText(Template);
            string completedTemplate = BuildTemplate(template, formulaReport);

            string baseFolder = $@"{Directory.GetCurrentDirectory()}\Template\";

            HtmlToPdf pdfMaker = new();
            var doc = pdfMaker.ConvertHtmlString(completedTemplate, baseFolder);
            var completedPath = $"../PDF/{formulaReport.Name}-Formula_Report.pdf";
            doc.Save(completedPath);
            doc.Close();

            System.Diagnostics.Process.Start("explorer", Path.GetFullPath(completedPath));
        }

        private string BuildTemplate(string template, FormulaReport formulaReport)
        {
            StringBuilder templateBuilder = new(template);

            templateBuilder.Replace("@Name", formulaReport.Name)
                            .Replace("@SkinType", formulaReport.SkinType)
                            .Replace("@Client", formulaReport.Client)
                            .Replace("@Description", formulaReport.Description)
                            .Replace("@Texture", formulaReport.Texture)
                            .Replace("@BatchSize", $"{formulaReport.BatchSize:N2} g")
                            .Replace("@Ph", formulaReport.PhLevel.ToString("N2"))
                            .Replace("@IngredientTable", IngredientsToTable(formulaReport.Ingredients))
                            .Replace("@Procedure", ListifyProcedure(formulaReport.Procedure))
                            .Replace("@Ingredients", ListifyIngredients(formulaReport.Ingredients));

            return templateBuilder.ToString();
        }

        private string ListifyIngredients(List<IngredientReport> ingredients)
        {
            StringBuilder sb = new();

            foreach (var ingredient in ingredients.OrderBy(x => x.InciName))
            {
                sb.Append($"<li>{ingredient.InciName}</li>");
            }

            return sb.ToString();
        }

        private string ListifyProcedure(string procedure)
        {
            string[] steps = procedure.Split($"{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new();

            foreach (var step in steps)
            {
                sb.Append($"<li>{step}</li>");
            }

            return sb.ToString();
        }

        private string IngredientsToTable(List<IngredientReport> ingredients)
        {
            StringBuilder sb = new();

            foreach (var ingredient in ingredients.OrderBy(x => x.Phase).ThenByDescending(x => x.Percentage))
            {
                sb.Append(IngredientToRow(ingredient));
            }

            sb.Append(IngredientTotal(ingredients));

            return sb.ToString();
        }

        private string IngredientTotal(List<IngredientReport> ingredients)
        {
            return $"<td></td><td></td><td></td><td></td><td class=\"result CenterText\">{ingredients.Sum(x => x.Percentage):P}</td><td class=\"result CenterText\">{ingredients.Sum(x => x.Pricing).ToString("C2", Culture)}</td><td class=\"result CenterText\">{ingredients.Sum(x => x.Cost).ToString("C2", Culture)}</td>";
        }

        private string IngredientToRow(IngredientReport ingredient)
        {
            return $"<tr>{FieldInTableCell(ingredient.Phase, true)}{FieldInTableCell($"{ingredient.InciName}")}{FieldInTableCell($"{ingredient.Name}")}{FieldInTableCell(ingredient.Description)}{FieldInTableCell($"{ingredient.Percentage:P}", true)}{FieldInTableCell($"{ingredient.Pricing.ToString("C2", Culture)}", true)}{FieldInTableCell(ingredient.Cost.ToString("C2", Culture), true)}</tr>";
        }

        private string FieldInTableCell(string content, bool center = false)
        {
            return $"<td {(center? $"class=\"CenterText\"" : "")}>{content}</td>";
        }
    }
}
