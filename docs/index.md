# Tasks

1. Git Repo

    [https://github.com/blackradley/coeus](https://github.com/blackradley/coeus)

2. Get the face detection app working
3. Prometheus Exporter
    *   Decide on language
    *   Decide on metrics to expose

### Essential

    *   CPU gauge
    *   Memory gauge
    *   Disk Space gauge
    *   Uptime
        *   Uptime (seconds) counter
    *   Services
        *   Coeus_up (0/1) _gauge_
        *   Exporter_up (0/1) _gauge_
    *   Face count
        *   current_faces (count) _gauge_
        *   Face_id (id)
        *   Total_faces (count) summary

### Nice to have

    *   Gender
        *   male/female
            1. Gender (0/1) _gauge_
    *   Age
        *   Age buckets >18 18<>65 <65 _histogram_
    *   Dwell duration
        *   Seconds
            2. Dwell_duration_seconds _gauge_
    *   Services
        *   Coeus_up (0/1) _gauge_
        *   Exporter_up (0/1) _gauge_
    *   Coeus
        *   API queries 
            3. API_calls (count) _gauge_
            4. API_request_time (seconds) _gauge_
        *   
    *   Exporter
        *   Exporter_scrape_duration_seconds _gauge_
        
4. Decide on port to scrape from - 8000
5. Prometheus Server
    *   Install 
    *   Configure
6. Grafana Server
    *   Install 
    *   Configure
7. VM created - 
    *   Done on digital ocean 
    *   134.209.25.208
    *   SSH access
8. Pi/computer to take pictures
9. Do we use / install Ansible
10. Firewall Rules to allow prometheus to scrape
11. Delivery pipeline??




# Steps to get started

[https://github.com/prometheus/client_python](https://github.com/prometheus/client_python)


```
pip install prometheus_client
Visual studio install extension
```


Promethues-client-python-snippets

 ap deploy-node-exporter.yml -i host_vars/coeus.yml

