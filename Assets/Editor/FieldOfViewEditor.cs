using UnityEditor;
using UnityEngine;

namespace DefaultNamespace {
	[CustomEditor(typeof(FieldOfView))]
	public class FieldOfViewEditor : Editor {
		private void OnSceneGUI() {
			var fov = (FieldOfView) target;
			Handles.color = Color.white;
			var position = fov.transform.position;

			Handles.DrawWireArc(position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

			var viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
			var viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

			Handles.DrawLine(position, position + viewAngleA * fov.viewRadius);
			Handles.DrawLine(position, position + viewAngleB * fov.viewRadius);

			Handles.color = Color.red;
			foreach (var target in fov.visibleTargets) {
				Handles.DrawLine(fov.transform.position, target.position);
			}
		}
	}
}