#!/usr/bin/env python3
"""
Simple server showing images
Usage::
    ./server.py [<port>]
"""
from http.server import BaseHTTPRequestHandler, HTTPServer
import logging
import cv2

class S(BaseHTTPRequestHandler):
    def _set_response(self):
        self.send_response(200)
        self.send_header('Content-type', 'text/html')
        self.end_headers()

    def do_GET(self):
        logging.info("GET request,\nPath: %s\nHeaders:\n%s\n", str(self.path), str(self.headers))
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
        self.send_response(200)
        self.send_header("Content-type", "image/jpg")
        #self.send_header("Content-length", img_size)
        self.end_headers() 
        f = open('capture.png', 'rb')
        self.wfile.write(f.read())
        f.close()   

    def do_POST(self):
        content_length = int(self.headers['Content-Length']) # <--- Gets the size of data
        post_data = self.rfile.read(content_length) # <--- Gets the data itself
        logging.info("POST request,\nPath: %s\nHeaders:\n%s\n\nBody:\n%s\n",
                str(self.path), str(self.headers), post_data.decode('utf-8'))

        self._set_response()
        self.wfile.write("POST request for {}".format(self.path).encode('utf-8'))

def run(server_class=HTTPServer, handler_class=S, port=8080):
    logging.basicConfig(level=logging.INFO)
    server_address = ('', port)
    httpd = server_class(server_address, handler_class)
    logging.info('Starting httpd...\n')
    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        pass
    httpd.server_close()
    logging.info('Stopping httpd...\n')

if __name__ == '__main__':
    from sys import argv

    if len(argv) == 2:
        run(port=int(argv[1]))
    else:
        run()