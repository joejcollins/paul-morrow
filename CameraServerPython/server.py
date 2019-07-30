""" Cheap as chips """
from flask import Flask
from flask import send_file
import cv2
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



if __name__ == '__main__':
    # local development server. 
    APP.run(debug=True)
