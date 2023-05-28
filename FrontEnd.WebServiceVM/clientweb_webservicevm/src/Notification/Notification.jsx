import React from 'react';
import NotificationsIcon from '@mui/icons-material/Notifications';
import Badge from '@mui/material/Badge';
import IconButton from '@mui/material/IconButton';
import { Tooltip } from '@mui/material';
const Notification = () => {
    return (
        <Tooltip title="Nouvelle Notification">
        <IconButton color='primary'>
        <Badge badgeContent={4} color="secondary">
            <NotificationsIcon />
        </Badge>
        </IconButton>
        </Tooltip>
    );
};
export default Notification;        