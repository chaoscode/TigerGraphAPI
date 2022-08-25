using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphAPI.Models.TigerGraphAPI
{


    public class Rootobject
    {
        public DELETEGraphDelete_By_TypeVerticesVertex_Type DELETEgraphdelete_by_typeverticesvertex_type { get; set; }
        public DELETEGraphEdgesSource_Vertex_TypeSource_Vertex_IdEdge_TypeTarget_Vertex_TypeTarget_Vertex_Id DELETEgraphedgessource_vertex_typesource_vertex_idedge_typetarget_vertex_typetarget_vertex_id { get; set; }
    }

    public class DELETEGraphDelete_By_TypeVerticesVertex_Type
    {
        public Parameters parameters { get; set; }
    }

    public class Parameters
    {
        public Ack ack { get; set; }
        public Permanent permanent { get; set; }
        public Vertex_Type vertex_type { get; set; }
    }

    public class Ack
    {
        public string _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string[] options { get; set; }
        public string type { get; set; }
    }

    public class Permanent
    {
        public bool _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Vertex_Type
    {
        public string type { get; set; }
    }

    public class DELETEGraphEdgesSource_Vertex_TypeSource_Vertex_IdEdge_TypeTarget_Vertex_TypeTarget_Vertex_Id
    {
        public Parameters1 parameters { get; set; }
    }

    public class Parameters1
    {
        public Edge_Type edge_type { get; set; }
        public Filter filter { get; set; }
        public Limit limit { get; set; }
        public Not_Wildcard not_wildcard { get; set; }
        public Permanent1 permanent { get; set; }
        public Select select { get; set; }
        public Sort sort { get; set; }
        public Source_Vertex_Id source_vertex_id { get; set; }
        public Source_Vertex_Type source_vertex_type { get; set; }
        public Target_Vertex_Id target_vertex_id { get; set; }
        public Target_Vertex_Type target_vertex_type { get; set; }
        public Timeout timeout { get; set; }
    }

    public class Edge_Type
    {
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Filter
    {
        public int max_count { get; set; }
        public int max_length { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Limit
    {
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Not_Wildcard
    {
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Permanent1
    {
        public bool _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Select
    {
        public int max_count { get; set; }
        public int max_length { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Sort
    {
        public int max_count { get; set; }
        public int max_length { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Source_Vertex_Id
    {
        public string id_type { get; set; }
        public bool is_id { get; set; }
        public int max_count { get; set; }
        public int max_length { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Source_Vertex_Type
    {
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Target_Vertex_Id
    {
        public string id_type { get; set; }
        public bool is_id { get; set; }
        public int max_count { get; set; }
        public int max_length { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Target_Vertex_Type
    {
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Timeout
    {
        public int _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }


    public class ResponsegetEndpoints
    {
        public List<GETEndpoints> GETendpoints = new List<GETEndpoints>();
    }

    public class GETEndpoints
    {
        public Parameters parameters { get; set; }
    }

    public class Parameters
    {
        public Builtin builtin { get; set; }
        public Dynamic dynamic { get; set; }
        public Static _static { get; set; }
    }

    public class Builtin
    {
        public string _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Dynamic
    {
        public string _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }

    public class Static
    {
        public string _default { get; set; }
        public int max_count { get; set; }
        public int min_count { get; set; }
        public string type { get; set; }
    }


}
