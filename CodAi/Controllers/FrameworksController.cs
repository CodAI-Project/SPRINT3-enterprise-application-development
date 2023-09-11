using CodAi.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace CodAi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : Controller
    {
        private FirestoreDb _db;

        public FrameworksController()
        {
            _db = FirestoreConnection.GetFirestoreDb();
        }

        [HttpGet]
        public async Task<IActionResult?> GetAllFrameworks()
        {
            try
            {
                CollectionReference frameworksCollection = _db.Collection("frameworks");
                QuerySnapshot querySnapshot = await frameworksCollection.GetSnapshotAsync();

                if (querySnapshot.Count > 0)
                {
                    List<Frameworks> frameworksList = new List<Frameworks>();

                    foreach (DocumentSnapshot documentSnapshot in querySnapshot)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Frameworks framework = documentSnapshot.ConvertTo<Frameworks>();
                            framework.Id = documentSnapshot.Id;
                            frameworksList.Add(framework);
                        }
                    }

                    return Ok(frameworksList);
                }
                else
                {
                    return NotFound("Nenhum framework encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os frameworks: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> GetFrameworks(string id)
        {
            DocumentReference documentReference = _db.Collection("frameworks").Document(id);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {

                Frameworks? framework = documentSnapshot.ConvertTo<Frameworks>();
                framework.Id = documentSnapshot.Id;

                return Ok(framework);
            }

            return NotFound();
        }

        // POST: api/Frameworks
        [HttpPost]
        public async Task<IActionResult?> CreateFrameworks(Frameworks frameworks)
        {
            try
            {
                DocumentReference docReference = _db.Collection("frameworks").Document();
                await docReference.SetAsync(frameworks);
                return Ok("Inserido com sucesso!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Frameworks
        [HttpPut]
        public async Task<IActionResult?> UpdateChat(Frameworks frameworks)
        {
            try
            {
                DocumentReference documentReference = _db.Collection("frameworks").Document(frameworks.Id);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    await documentReference.SetAsync(frameworks, SetOptions.Overwrite);
                    return Ok("Framework alterado com sucesso!");
                }
                else
                {
                    return NotFound("Framework não encontrado.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // DELETE: api/Frameworks/id
        [HttpDelete("{id}")]
        public async Task<IActionResult?> DeleteFrameworks(string id)
        {
            try
            {
                DocumentReference documentReference = _db.Collection("frameworks").Document(id);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    await documentReference.DeleteAsync();
                    return Ok("Framework deletado com sucesso!");
                }
                else
                {
                    return NotFound("Framework não encontrado.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
