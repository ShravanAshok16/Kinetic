import { List, ListItem, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import axios from "axios";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  // Fetch activities from the API when the component mounts
  useEffect(() => {
    axios("https://localhost:5001/api/activities")
      .then((response) => setActivities(response.data))
      .catch((error) => console.error("Error fetching activities:", error));
  }, []);
  return (
    <>
      <Typography variant='h3' className="appName" style={{ fontWeight: "bold", color: "green" }}>
        Kinetic
      </Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <Typography variant='h5'>{activity.title}</Typography>
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App
