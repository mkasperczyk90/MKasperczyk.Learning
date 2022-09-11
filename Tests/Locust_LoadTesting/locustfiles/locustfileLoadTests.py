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
        {"duration": 300, "users": 70, "spawn_rate": 1, "user_classes": [UserTasks]},
        {"duration": 600, "users": 70, "spawn_rate": 1, "user_classes": [UserTasks]},
        {"duration": 300, "users": 0, "spawn_rate": 1, "user_classes": [UserTasks]},
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