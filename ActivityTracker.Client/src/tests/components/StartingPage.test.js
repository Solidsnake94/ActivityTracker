import React from 'react';
import ReactShallowRender from 'react-test-renderer/shallow';

import StartingPage from '../../components/StartingPage';

test('should render startingpage correctly', () => {
    const renderer = new ReactShallowRender();

    renderer.render(< StartingPage />);
    expect(renderer.getRenderOutput()).toMatchSnapshot();
});