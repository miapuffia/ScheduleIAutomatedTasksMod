#if IL2CPP
using Il2CppGameKit.Utilities;
using Il2CppInterop.Runtime.InteropTypes;

#elif MONO
using GameKit.Utilities;
#endif
using MelonLoader;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace AutomatedTasksMod {
	internal class Utils {
		private const int FramesToSetValues = 5;

		internal static System.Collections.IEnumerator LerpPositionCoroutine(Transform transform, Vector3 targetPosition, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;
			Vector3 startPosition = transform.position;

			while(time < duration) {
				if(transform == null) {
					onError?.Invoke();
					yield break;
				}

				float t = time / duration;
				Vector3 pos = startPosition;

				pos.y = Mathf.Lerp(startPosition.y, targetPosition.y, t);
				pos.x = Mathf.Lerp(startPosition.x, targetPosition.x, t);
				pos.z = Mathf.Lerp(startPosition.z, targetPosition.z, t);

				transform.position = pos;

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					if(transform == null) {
						onError?.Invoke();
						yield break;
					}

					transform.position = targetPosition;

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator SinusoidalLerpPositionCoroutine(Transform transform, Vector3 targetPosition, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;
			Vector3 startPosition = transform.position;

			while(time < duration) {
				if(transform == null) {
					onError?.Invoke();
					yield break;
				}

				float t = time / duration;
				float yT = Mathf.Sin(t * Mathf.PI / 2);
				float xT = ((Mathf.Cos(t * Mathf.PI) / -2) + 0.5f);
				Vector3 pos = startPosition;

				pos.x = Mathf.Lerp(startPosition.x, targetPosition.x, xT);
				pos.y = Mathf.Lerp(startPosition.y, targetPosition.y, yT);
				pos.z = Mathf.Lerp(startPosition.z, targetPosition.z, yT);

				transform.position = pos;

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					if(transform == null) {
						onError?.Invoke();
						yield break;
					}

					transform.position = targetPosition;

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator SinusoidalLerpPositionsCoroutine(Transform[] transforms, Vector3 positionModifier, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;

			Vector3[] startPositions = [.. transforms.Select(t => t.position)];
			Vector3 startPosition;

			while(time < duration) {
				for(int i = 0; i < transforms.Length; i++) {
					if(transforms[i] == null) {
						onError?.Invoke();
						yield break;
					}

					float t = time / duration;
					float yT = Mathf.Sin(t * Mathf.PI / 2);
					float xT = ((Mathf.Cos(t * Mathf.PI) / -2) + 0.5f);

					startPosition = startPositions[i];
					Vector3 pos = startPosition;

					pos.x = Mathf.Lerp(startPosition.x, startPosition.x + positionModifier.x, xT);
					pos.y = Mathf.Lerp(startPosition.y, startPosition.y + positionModifier.y, yT);
					pos.z = Mathf.Lerp(startPosition.z, startPosition.z + positionModifier.z, yT);

					transforms[i].position = pos;
				}

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					for(int j = 0; j < transforms.Length; j++) {
						if(transforms[j] == null) {
							onError?.Invoke();
							yield break;
						}

						transforms[j].position = new Vector3(startPositions[j].x + positionModifier.x, startPositions[j].y + positionModifier.y, startPositions[j].z + positionModifier.z);
					}

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator LerpRotationCoroutine(Transform transform, Vector3 targetAngle, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;
			Vector3 startRotation = transform.localEulerAngles;

			while(time < duration) {
				if(transform == null) {
					onError?.Invoke();
					yield break;
				}

				float t = time / duration;
				Vector3 rot = startRotation;

				rot.x = Mathf.Lerp(startRotation.x, targetAngle.x, t);
				rot.y = Mathf.Lerp(startRotation.y, targetAngle.y, t);
				rot.z = Mathf.Lerp(startRotation.z, targetAngle.z, t);

				transform.localEulerAngles = rot;

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					if(transform == null) {
						onError?.Invoke();
						yield break;
					}

					transform.localEulerAngles = targetAngle;

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator SinusoidalLerpRotationCoroutine(Transform transform, Vector3 targetAngle, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;
			Vector3 startRotation = transform.localEulerAngles;

			while(time < duration) {
				if(transform == null) {
					onError?.Invoke();
					yield break;
				}

				float t = time / duration;
				float aT = ((Mathf.Cos(t * Mathf.PI) / -2) + 0.5f);
				Vector3 rot = startRotation;

				rot.x = Mathf.Lerp(startRotation.x, targetAngle.x, aT);
				rot.y = Mathf.Lerp(startRotation.y, targetAngle.y, aT);
				rot.z = Mathf.Lerp(startRotation.z, targetAngle.z, aT);

				transform.localEulerAngles = rot;

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					if(transform == null) {
						onError?.Invoke();
						yield break;
					}

					transform.localEulerAngles = targetAngle;

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator SinusoidalLerpPositionAndRotationCoroutine(Transform transform, Vector3 targetPosition, Vector3 targetAngle, float duration, Action onError = null, bool correctForLag = true) {
			float time = 0;
			Vector3 startPosition = transform.position;
			Vector3 startRotation = transform.localEulerAngles;

			while(time < duration) {
				if(transform == null) {
					onError?.Invoke();
					yield break;
				}

				float t = time / duration;
				float yT = Mathf.Sin(t * Mathf.PI / 2);
				float xT = ((Mathf.Cos(t * Mathf.PI) / -2) + 0.5f);
				float aT = ((Mathf.Cos(t * Mathf.PI) / -2) + 0.5f);

				Vector3 pos = startPosition;
				Vector3 rot = startRotation;

				pos.x = Mathf.Lerp(startPosition.x, targetPosition.x, xT);
				pos.y = Mathf.Lerp(startPosition.y, targetPosition.y, yT);
				pos.z = Mathf.Lerp(startPosition.z, targetPosition.z, yT);

				rot.x = Mathf.Lerp(startRotation.x, targetAngle.x, aT);
				rot.y = Mathf.Lerp(startRotation.y, targetAngle.y, aT);
				rot.z = Mathf.Lerp(startRotation.z, targetAngle.z, aT);

				transform.position = pos;
				transform.localEulerAngles = rot;

				time += Time.deltaTime;
				yield return null;
			}

			//Attempt to counteract lag by forcing the correct position for multiple frames
			if(correctForLag) {
				for(int i = 0; i < FramesToSetValues; i++) {
					if(transform == null) {
						onError?.Invoke();
						yield break;
					}

					transform.position = targetPosition;
					transform.localEulerAngles = targetAngle;

					yield return null;
				}
			}
		}

		internal static System.Collections.IEnumerator LerpFloatCallbackCoroutine(float start, float end, float duration, Func<float, bool> body) {
			float time = 0;
			float delta = end - start;

			while(time < duration) {
				float t = time / duration;

				if(!body.Invoke(start + (delta * t)))
					yield break;

				time += Time.deltaTime;
				yield return null;
			}

			body.Invoke(end);
		}

		internal static bool NullCheck(object obj, string message = null) {
			bool isNull;

#if IL2CPP
			if(obj is GameObject) {
				isNull = (obj as GameObject) == null || (obj as GameObject).IsDestroyed() || (obj as GameObject).WasCollected;
			} else if(obj is Component) {
				isNull = (obj as Component) == null || (obj as Component).WasCollected || (obj as Component).gameObject == null || (obj as Component).gameObject.IsDestroyed() || (obj as Component).gameObject.WasCollected;
			} else {
				isNull = obj == null;
			}
#elif MONO
			if(obj is GameObject) {
				isNull = (obj as GameObject) == null || (obj as GameObject).IsDestroyed();
			} else if(obj is Component) {
				isNull = (obj as Component) == null || (obj as Component).gameObject == null || (obj as Component).gameObject.IsDestroyed();
			} else {
				isNull = obj == null;
			}
#endif

			if(isNull && message != null) {
				Melon<Mod>.Logger.Msg(message);
			}

			return isNull;
		}

		internal static bool NullCheck(object[] obj, string message = null) {
			foreach(object o in obj) {
				if(NullCheck(o)) {
					if(message != null)
						Melon<Mod>.Logger.Msg(message);

					return true;
				}
			}

			return false;
		}

#if IL2CPP
		internal static bool TypeCheck<T>(Il2CppObjectBase obj, out T value, string message = null) where T : Il2CppObjectBase {
			T castedValue = obj.BackendTryCast<T>();
#elif MONO
		internal static bool TypeCheck<T>(object obj, out T value, string message = null) where T : class {
			T castedValue = obj as T;
#endif

			if(castedValue == null) {
				if(message != null)
					Melon<Mod>.Logger.Msg(message + " (" + obj.GetType().Name + ")");

				value = default;
				return true;
			} else {
				value = castedValue;
				return false;
			}
		}

		internal static System.Collections.IEnumerator SimulateKeyPress(KeyControl keyControl) {
			InputEventPtr eventPtr;

			StateEvent.From(Keyboard.current.device, out eventPtr);
			keyControl.WriteValueIntoEvent(0f, eventPtr);
			InputSystem.QueueEvent(eventPtr);

			yield return new WaitForSeconds(0.1f);

			StateEvent.From(Keyboard.current.device, out eventPtr);
			keyControl.WriteValueIntoEvent(1f, eventPtr);
			InputSystem.QueueEvent(eventPtr);
		}
	}
}
