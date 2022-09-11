from locust import HttpUser, TaskSet, task, constant
from locust import LoadTestShape

class UserTasks(HttpUser):
    host = "http://localhost:5173"

    @task
    def users(self):
        self.client.get("/users")

    @task
    def news(self):
        self.client.get("/news")


class StagesShapeWithCustomUsers(LoadTestShape):

    stages = [
        {"duration": 120, "users": 200, "spawn_rate": 1, "user_classes": [UserTasks]},
        {"duration": 60*60*3, "users": 200, "spawn_rate": 1, "user_classes": [UserTasks]}, #3h
        {"duration": 120, "users": 0, "spawn_rate": 1, "user_classes": [UserTasks]},
    ]
    def tick(self):
        run_time = self.get_run_time()

        for stage in self.stages:
            if run_time < stage["duration"]:
                try:
                    tick_data = (stage["users"], stage["spawn_rate"], stage["user_classes"])
                except:
                    tick_data = (stage["users"], stage["spawn_rate"])
                return tick_data

        return None