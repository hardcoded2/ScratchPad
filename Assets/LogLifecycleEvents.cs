
using UnityEngine;

public class LogLifecycleEvents
{
    [RuntimeInitializeOnLoadMethod]
    public static void SetupLogging()
    {
        var go = new GameObject("LifecycleEvents");
        go.SetActive(false); //prevent awake
        var proxy = go.AddComponent<MonobehaviourLifecycleProxy>();
        
        var events = new MonobehaviourLifecycleEvents();
        AddLoggingEvents(events);

        proxy.Callbacks = events;
        go.SetActive(true); //allow awake again
    }

    public static void AddLoggingEvents(MonobehaviourLifecycleEvents monobehaviourCallbacks)
    {
        monobehaviourCallbacks.Awake += ()=>Debug.Log($"Awake()");
        monobehaviourCallbacks.Reset += ()=>Debug.Log($"Reset()");
        monobehaviourCallbacks.Start += ()=>Debug.Log($"Start()");
        monobehaviourCallbacks.Update += ()=>Debug.Log($"Update()");
        monobehaviourCallbacks.FixedUpdate += ()=>Debug.Log($"FixedUpdate()");
        monobehaviourCallbacks.LateUpdate += ()=>Debug.Log($"LateUpdate()");
        monobehaviourCallbacks.OnEnable += ()=>Debug.Log($"OnEnable()");
        monobehaviourCallbacks.OnDisable += ()=>Debug.Log($"OnDisable()");
        monobehaviourCallbacks.OnDestroy += ()=>Debug.Log($"OnDestroy()");
        monobehaviourCallbacks.OnGUI += ()=>Debug.Log($"OnGUI()");
        monobehaviourCallbacks.OnAnimatorIK += (int layerIndex)=>Debug.Log($"OnAnimatorIK(int layerIndex) {layerIndex}");
        monobehaviourCallbacks.OnAnimatorMove += ()=>Debug.Log($"OnAnimatorMove()");
        monobehaviourCallbacks.OnApplicationFocus += (bool hasFocus)=>Debug.Log($"OnApplicationFocus(bool hasFocus) {hasFocus}");
        monobehaviourCallbacks.OnApplicationPause += (bool pauseStatus)=>Debug.Log($"OnApplicationPause(bool pauseStatus) {pauseStatus}");
        monobehaviourCallbacks.OnApplicationQuit += ()=>Debug.Log($"OnApplicationQuit()");
        monobehaviourCallbacks.OnAudioFilterRead += (float[] data, int channels)=>Debug.Log($"OnAudioFilterRead(float[] data, int channels)");
        monobehaviourCallbacks.OnBecameInvisible += ()=>Debug.Log($"OnBecameInvisible()");
        monobehaviourCallbacks.OnBecameVisible += ()=>Debug.Log($"OnBecameVisible()");
        monobehaviourCallbacks.OnBeforeTransformParentChanged += ()=>Debug.Log($"OnBeforeTransformParentChanged()");
        monobehaviourCallbacks.OnCanvasGroupChanged += ()=>Debug.Log($"OnCanvasGroupChanged()");
        monobehaviourCallbacks.OnCanvasHierarchyChanged += ()=>Debug.Log($"OnCanvasHierarchyChanged()");
        monobehaviourCallbacks.OnCollisionEnter += (Collision other)=>Debug.Log($"OnCollisionEnter(Collision other) {other.gameObject.name}");
        monobehaviourCallbacks.OnCollisionEnter2D += (Collision2D other)=>Debug.Log($"OnCollisionEnter2D(Collision2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnCollisionExit += (Collision other)=>Debug.Log($"OnCollisionExit(Collision other) {other.gameObject.name}");
        monobehaviourCallbacks.OnCollisionExit2D += (Collision2D other)=>Debug.Log($"OnCollisionExit2D(Collision2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnCollisionStay += (Collision other)=>Debug.Log($"OnCollisionStay(Collision other) {other.gameObject.name}");
        monobehaviourCallbacks.OnCollisionStay2D += (Collision2D other)=>Debug.Log($"OnCollisionStay2D(Collision2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnConnectedToServer += ()=>Debug.Log($"OnConnectedToServer()");
        monobehaviourCallbacks.OnControllerColliderHit += (ControllerColliderHit hit)=>Debug.Log($"OnControllerColliderHit(ControllerColliderHit hit) {hit.gameObject.name}");
        monobehaviourCallbacks.OnDidApplyAnimationProperties += ()=>Debug.Log($"OnDidApplyAnimationProperties()");
        monobehaviourCallbacks.OnDrawGizmos += ()=>Debug.Log($"OnDrawGizmos()");
        monobehaviourCallbacks.OnDrawGizmosSelected += ()=>Debug.Log($"OnDrawGizmosSelected()");
        monobehaviourCallbacks.OnJointBreak += (float breakForce)=>Debug.Log($"OnJointBreak(float breakForce) {breakForce}");
        monobehaviourCallbacks.OnJointBreak2D += (Joint2D brokenJoint)=>Debug.Log($"OnJointBreak2D(Joint2D brokenJoint) {brokenJoint}");
        monobehaviourCallbacks.OnMouseDown += ()=>Debug.Log($"OnMouseDown()");
        monobehaviourCallbacks.OnMouseDrag += ()=>Debug.Log($"OnMouseDrag()");
        monobehaviourCallbacks.OnMouseEnter += ()=>Debug.Log($"OnMouseEnter()");
        monobehaviourCallbacks.OnMouseExit += ()=>Debug.Log($"OnMouseExit()");
        monobehaviourCallbacks.OnMouseOver += ()=>Debug.Log($"OnMouseOver()");
        monobehaviourCallbacks.OnMouseUp += ()=>Debug.Log($"OnMouseUp()");
        monobehaviourCallbacks.OnMouseUpAsButton += ()=>Debug.Log($"OnMouseUpAsButton()");
        monobehaviourCallbacks.OnParticleCollision += (GameObject other)=>Debug.Log($"OnParticleCollision(GameObject other) {other.name}");
        monobehaviourCallbacks.OnParticleSystemStopped += ()=>Debug.Log($"OnParticleSystemStopped()");
        monobehaviourCallbacks.OnParticleTrigger += ()=>Debug.Log($"OnParticleTrigger()");
        monobehaviourCallbacks.OnParticleUpdateJobScheduled += ()=>Debug.Log($"OnParticleUpdateJobScheduled()");
        monobehaviourCallbacks.OnPostRender += ()=>Debug.Log($"OnPostRender()");
        monobehaviourCallbacks.OnPreCull += ()=>Debug.Log($"OnPreCull()");
        monobehaviourCallbacks.OnPreRender += ()=>Debug.Log($"OnPreRender()");
        monobehaviourCallbacks.OnRectTransformDimensionsChange += ()=>Debug.Log($"OnRectTransformDimensionsChange()");
        monobehaviourCallbacks.OnRenderImage += (RenderTexture src, RenderTexture dest)=>Debug.Log($"OnRenderImage(RenderTexture src, RenderTexture dest)");
        monobehaviourCallbacks.OnRenderObject += ()=>Debug.Log($"OnRenderObject()");
        monobehaviourCallbacks.OnServerInitialized += ()=>Debug.Log($"OnServerInitialized()");
        monobehaviourCallbacks.OnTransformChildrenChanged += ()=>Debug.Log($"OnTransformChildrenChanged()");
        monobehaviourCallbacks.OnTransformParentChanged += ()=>Debug.Log($"OnTransformParentChanged()");
        monobehaviourCallbacks.OnTriggerEnter += (Collider other)=>Debug.Log($"OnTriggerEnter(Collider other) {other.gameObject.name}");
        monobehaviourCallbacks.OnTriggerEnter2D += (Collider2D other)=>Debug.Log($"OnTriggerEnter2D(Collider2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnTriggerExit += (Collider other)=>Debug.Log($"OnTriggerExit(Collider other) {other.gameObject.name}");
        monobehaviourCallbacks.OnTriggerExit2D += (Collider2D other)=>Debug.Log($"OnTriggerExit2D(Collider2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnTriggerStay += (Collider other)=>Debug.Log($"OnTriggerStay(Collider other) {other.gameObject.name}");
        monobehaviourCallbacks.OnTriggerStay2D += (Collider2D other)=>Debug.Log($"OnTriggerStay2D(Collider2D other) {other.gameObject.name}");
        monobehaviourCallbacks.OnValidate += ()=>Debug.Log($"OnValidate()");
        monobehaviourCallbacks.OnWillRenderObject += ()=>Debug.Log($"OnWillRenderObject()");
    }
}