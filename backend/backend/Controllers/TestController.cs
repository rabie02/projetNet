using backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace backend.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        private readonly MagasinDB2Entities _context = new MagasinDB2Entities(); // Assurez-vous d'ajuster le contexte de base de données
        [HttpPost]
        [Route("Registration")]
        public IHttpActionResult Registration(client c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Vérifiez si l'email existe déjà dans la base de données
                    if (_context.client.Any(existingClient => existingClient.email == c.email))
                    {
                        return BadRequest("Email already exists");
                    }
                    // Ajoutez le nouveau client à la base de données
                    _context.client.Add(c);
                    _context.SaveChanges();

                    return Ok("Registration successful");
                }
                else
                {
                    // Le modèle n'est pas valide, renvoyez une erreur avec les détails du modèle
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Une erreur s'est produite pendant l'enregistrement, renvoyez une erreur avec les détails de l'exception
                return InternalServerError(ex);
            }
        }
        // Ajoutez la méthode de login dans votre contrôleur
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(client loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Vérifiez si les informations de connexion sont valides dans la base de données
                    var existingClient = _context.client
                        .FirstOrDefault(client => client.email == loginModel.email && client.password == loginModel.password);
                    if (existingClient != null)
                    {
                        // Connexion réussie
                        // Vous pouvez également générer un jeton d'authentification JWT ici

                        return Ok("Login successful");
                    }
                    else
                    {
                        // Informations de connexion incorrectes
                        return BadRequest("Invalid email or password");
                    }
                }
                else
                {
                    // Le modèle n'est pas valide, renvoyez une erreur avec les détails du modèle
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Une erreur s'est produite pendant la connexion, renvoyez une erreur avec les détails de l'exception
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/Product")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var allProducts = _context.product.ToList();
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Product/{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                var product = _context.product.FirstOrDefault(p => p.id_product == id);

                if (product != null)
                    return Ok(product);
                else
                    return NotFound(); // Le produit n'a pas été trouvé
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
       
        [HttpPost]
        [Route("api/Commande")]
        public IHttpActionResult AddCommande(commande nouvelleCommande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Ajoutez la nouvelle commande à la base de données
                    _context.commande.Add(nouvelleCommande);
                    _context.SaveChanges();

                    return Ok("Commande ajoutée avec succès");
                }
                else
                {
                    // Le modèle n'est pas valide, renvoyez une erreur avec les détails du modèle
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Une erreur s'est produite pendant l'ajout de la commande, renvoyez une erreur avec les détails de l'exception
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/UserCommands/{email}")]
        public IHttpActionResult GetUserCommands(string email)
        {
            try
            {
                // Assuming that 'nom' is the property representing the email in your data model
                var userCommands = _context.commande.Where(cmd => cmd.nom == email).ToList();
                // Log the user commands for debugging purposes
                Console.WriteLine($"User Commands for {email}: {JsonConvert.SerializeObject(userCommands)}");

                return Ok(userCommands);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // ... (autres méthodes du contrôleur)
    }
}

