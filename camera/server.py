""" Cheap as chips """

from flask import Flask
from flask import send_file
import cv2
import cognitive_face as azure
import prometheus_client
import secret

APP = Flask(__name__)

@APP.route('/')
def capture_image():
    """ Save the image and sent it back """
    video_capture = cv2.VideoCapture(0)
    # Check success
    if not video_capture.isOpened():
        raise Exception("Could not open video device")
    # Read picture. ret === True on success
    has_no_errors, frame = video_capture.read()
    if has_no_errors:
        cv2.imwrite('capture.png', frame)
    # Close device
    video_capture.release()
    return send_file('capture.png', mimetype='image/png')

@APP.route('/how_many_faces')
def how_many_faces():
    """ Return how many faces there are """
    capture_image()
    return "Found {0} faces!".format(count_faces())

def count_faces():
    """ Count the number of faces """
    face_cascade = cv2.CascadeClassifier('data/haarcascade_frontalface_alt.xml')
    image = cv2.imread('capture.png')
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    # Detect faces in the image
    faces = face_cascade.detectMultiScale(
        gray,
        scaleFactor=1.1,
        minNeighbors=5,
        minSize=(30, 30),
        flags=cv2.CASCADE_SCALE_IMAGE
    )
    return len(faces)

@APP.route('/json')
def azure_face_response():
    """ Return the Azure face stuff """
    capture_image()
    if count_faces() > 0:
        key = secret.key
        azure.Key.set(key)
        url = 'https://coeus-face.cognitiveservices.azure.com/face/v1.0' 
        azure.BaseUrl.set(url)
        result = azure.face.detect('capture.png', attributes="age,gender")
        return "{}".format(result)
    else:
        return "Can't see anyone"

@APP.route('/metrics', methods=['GET'])
def metrics():
    return prometheus_client.generate_latest(), 200

if __name__ == '__main__':
    # local development server. 
    APP.run(host='0.0.0.0', threaded=True, debug=True)
