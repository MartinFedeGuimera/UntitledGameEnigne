using OpenTK.Mathematics;

namespace UntitledGameEngine.Collision
{
    public class CollisionSystem
    {
        private List<Collider> colliders = new List<Collider>();

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }

        public void Update()
        {
            DetectCollisions();
        }

        private bool DetectCollisions()
        {
            for(int i = 0; i < colliders.Count; i++)
            {
                Collider a = colliders[i];

                for (int j = i + 1; j < colliders.Count; j++)
                {
                    Collider b = colliders[j];

                    Vector2[] normals = CalculateNormals(a, b);

                    foreach(var normal in normals)
                    {
                        var aProjection = Proyect(a.GetVertices(), normal);
                        var bProjection = Proyect(b.GetVertices(), normal);

                        if(aProjection.min > bProjection.max || bProjection.min > aProjection.max)
                        {
                            Console.WriteLine("No Collision Detected!");
                            return false;
                        }
                    }
                }
            }

            Console.WriteLine("Collision Detected!");
            return true;
        }

        private Vector2[] CalculateNormals(Collider a, Collider b)
        {
            Vector2[] normals = new Vector2[a.GetNormals().Length + b.GetNormals().Length];

            for (int k = 0; k < a.GetNormals().Length; k++)
            {
                normals[k] = a.GetNormals()[k];
            }
            for (int k = 0; k < b.GetNormals().Length; k++)
            {
                normals[k + a.GetNormals().Length] = b.GetNormals()[k];
            }

            return normals;
        }

        private (float min, float max) Proyect(Vector2[] vertices, Vector2 normal)
        {
            float[] projections = new float[vertices.Length];

            for(int i = 0; i < vertices.Length; i++)
            {
                var projection = Vector2.Dot(vertices[i], normal);
                projections[i] = projection;
            }

            return (projections.Min(), projections.Max());
        }
    }
}
