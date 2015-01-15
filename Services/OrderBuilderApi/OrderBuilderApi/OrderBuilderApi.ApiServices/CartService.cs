using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using JetBrains.Annotations;
using Newtonsoft.Json;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.ApiServices
{
    public interface ICartService
    {
        Cart CreateCart();
        Cart GetCart(int id);
        void DeleteCart(int id);

        List<Item> GetItems(int cartId);
        Item GetItem(int cartId, int itemId);
        Item AddItem(int cartId, int itemId);
        Item UpdateItem(int cartId, int itemId);
        void RemoveItem(int cartId, int itemId);
    }

    public class CartService : ICartService
    {
        private readonly string _cartServiceBaseUri;

        public CartService()
        {
            //if (cartServiceBaseUri == null) throw new ArgumentNullException("cartServiceBaseUri");
            //_cartServiceBaseUri = cartServiceBaseUri;
            _cartServiceBaseUri = "http://localhost:51402/";
        }

        public Cart CreateCart()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_cartServiceBaseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("Carts", new StringContent("", Encoding.UTF8, "application/json")).Result; 

                if (response.StatusCode != HttpStatusCode.Created)
                    throw new HttpException("Error creating cart");

                using (var res = response.Content.ReadAsStringAsync())
                {
                    var json = res.Result;
                    try
                    {
                        return JsonConvert.DeserializeObject<Cart>(json);
                    }
                    catch (Exception ex)
                    {
                        throw new HttpException(string.Format("Error deserializing the response from the order api: {0} Response: {1}", ex.Message, response));
                    }
                }
            }
        }

        public Cart GetCart(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_cartServiceBaseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("Carts", CancellationToken.None).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new HttpException("Error getting cart");

                using (var res = response.Content.ReadAsStringAsync())
                {
                    var json = res.Result;
                    try
                    {
                        return JsonConvert.DeserializeObject<Cart>(json);
                    }
                    catch (Exception ex)
                    {
                        throw new HttpException(string.Format("Error deserializing the response from the order api: {0} Response: {1}", ex.Message, response));
                    }
                }
            }
        }

        public void DeleteCart(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_cartServiceBaseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.DeleteAsync("Carts", CancellationToken.None).Result;

                if (response.StatusCode != HttpStatusCode.NoContent)
                    throw new HttpException("Error deleting cart");
            }
        }

        public List<Item> GetItems(int cartId)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int cartId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Item AddItem(int cartId, int itemId)
        {
            throw new NotImplementedException();
        }

        public Item UpdateItem(int cartId, int itemId)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int cartId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
