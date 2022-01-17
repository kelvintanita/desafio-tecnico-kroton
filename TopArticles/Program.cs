using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TopArticles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Informe o limite de busca dos Top Articles (1-10):");
                int limit = 0;
                var convertido = int.TryParse(Console.ReadLine().ToString(), out limit);

                if (convertido)
                {
                    List<Article> result = await GetTopArticles(limit);

                    Console.WriteLine("=========== TOP ARTICLES RESULT =========== \n\n");

                    foreach (var item in result)
                    {
                        if (!string.IsNullOrEmpty(item.title))
                            Console.WriteLine(item.title + "\n");
                        else
                            Console.WriteLine(item.story_title + "\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("ERRO: Informe somente números de 1 a 10 \n\n");
                }
            }
        }

        private static async Task<List<Article>> GetTopArticles(int limit)
        {
            var totalPages = 1;
            var orderResult = new List<Article>();

            for (int i = 0; i < totalPages; i++)
            {
                var result = await "https://jsonmock.hackerrank.com/".AppendPathSegment("/api/articles")
                                                                 .SetQueryParams(new
                                                                 {
                                                                     page = i
                                                                 })
                                                                  .GetJsonAsync<Articles>();
                totalPages = result.total_pages.Value;

                foreach (var item in result.data)
                {
                    orderResult.Add(item);
                }
            }

            orderResult = orderResult.OrderByDescending(o => o.num_comments)
                                     .Take(limit)
                                     .ToList();
            return orderResult;
        }
    }
}
